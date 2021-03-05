using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using grpcServisi;
using Identity50.Server.Model;
using Identity50.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Identity50.Server
{
    public class Servisi : grpcServisi.GrpcIdentity.GrpcIdentityBase
    {
		private readonly ILogger<Servisi> _log;
		private readonly UserManager<IdentityUser> _uman;
		private readonly SignInManager<IdentityUser> _sim;
		private DBcon Baza { get; init; }

		public Servisi(ILogger<Servisi> log, UserManager<IdentityUser> um, SignInManager<IdentityUser> sim, DBcon b)
		{
			_log = log;
			_uman = um;
			_sim = sim;
			Baza = b;
		}


		public override async Task<EmptyMsg> Upload(IAsyncStreamReader<FajlMsg> requestStream, ServerCallContext context)
		{
			_log.LogInformation("Krece prijem");
			Fajl faa = new Fajl {ID = Guid.NewGuid().ToString() };
			List<byte> temp = new List<byte>();

			await foreach(FajlMsg f in requestStream.ReadAllAsync())
			{
				_log.LogInformation(f.Bajt.ToList().Aggregate("Dobio bajte: ", 
					(akumulator, b) 
						=> akumulator += " " + b));

				f.Bajt.ToList().ForEach(b => temp.Add((byte)b));
			}
			_log.LogInformation("Snimam u bazu...");
			faa.Bajti = temp.ToArray();
			Baza.Fajls.Add(faa);
			Baza.SaveChanges();
			_log.LogInformation("Sve gotovo");
			return new EmptyMsg();
		}

		public override async Task Download(EmptyMsg request, IServerStreamWriter<FajlMsg> responseStream, ServerCallContext context)
		{
			_log.LogInformation("Krece metoda");
			var fajl = Baza.Fajls.First();
			_log.LogInformation("Krecem sa slanjem");
			FajlMsg fm = new FajlMsg();
			for (int i = 0; i < fajl.Bajti.Length; i++)
			{
				fm.Bajt.Add(fajl.Bajti[i]);
				if ((i+1)%10 == 0)
				{
					_log.LogInformation("Saljem chunk");
					await responseStream.WriteAsync(fm);
					fm = new FajlMsg();
				}
			}
			if (fm.Bajt.Any())
			{
				await responseStream.WriteAsync(fm);
				_log.LogInformation("Saljem chunk");
			}
			_log.LogInformation("Zavrsio slanje");
		}

		public override async Task<StandardReplyMsg> UnosKnjige(KnjigaMsg request, ServerCallContext context)
		{
			var knji = Baza.Knjigas.Where(k => k.Naziv == request.Naziv).FirstOrDefault();
			if (knji == null)
			{
				Knjiga knjiga = request;
				knjiga.Autori = new List<Autor>();
				List<Autor> aut = new List<Autor>();
				request.Autori.ToList().ForEach(a =>
				{
					var autorBaza = Baza.Autors.Where(au => au.Ime == a.Ime).FirstOrDefault();
					if (autorBaza == null)
						aut.Add(a);
					else
						aut.Add(autorBaza);
				});
				//knjiga.Autori = aut;
				//knji = Baza.Knjigas.Add(knjiga).Entity;
				Baza.KnjigaAutors.Add(new KnjigaAutor { Knjiga = knjiga, Autor = aut.Last(), Izdata = DateTime.Now });
				await Baza.SaveChangesAsync();
				knji = Baza.Knjigas.Find(knjiga.ID);
			} else
			{
				request.Autori.ToList().ForEach(a =>
				{
					var aut = Baza.Autors.Where(au => au.Ime == a.Ime).FirstOrDefault();
					Autor autoZaKnjigu = null;
					if (aut == null)
					{
						autoZaKnjigu = Baza.Autors.Add(a).Entity;
						knji.Autori.Add(autoZaKnjigu);
						Baza.SaveChanges();
					}

				});
			}
			return new StandardReplyMsg { Uspeh = true, Knjiga = knji };
		}

		public override async Task<StandardReplyMsg> Registracija(RegMsg request, ServerCallContext context)
		{
			IdentityUser kor;

			if (request.TipCase == RegMsg.TipOneofCase.Korisnik)
				kor = new Korisnik
				{
					UserName = request.Username,
					Ime = request.Korisnik.Ime, 
					Prezime = request.Korisnik.Prezime 
				};
			else if (request.TipCase == RegMsg.TipOneofCase.Zaposleni)
				kor = new Zaposlen
				{
					UserName = request.Username,
					Ime = request.Zaposleni.Ime,
					Prezime = request.Zaposleni.Prezime,
					Pozicija = request.Zaposleni.Pozicija
				};
			else
			{
				_log.LogError("Dobio poruku za login umesto za registraciju!");
				return new StandardReplyMsg { Uspeh = false, Greska = "Dobio poruku za login umesto za registraciju!" };
			}


			var rezultat = await _uman.CreateAsync(kor, request.Password);

			if (rezultat.Succeeded)
			{
				var usr = await _uman.FindByNameAsync(request.Username);
				await _uman.AddToRoleAsync(usr, "Admin");
				return new StandardReplyMsg { Uspeh = true };
			}
			else
				return new StandardReplyMsg
				{
					Uspeh = false,
					Greska = rezultat.Errors
					.Select(e => e.Description)
					.Aggregate((sveGreske, greska) => sveGreske += greska + System.Environment.NewLine)
				};

			//Agregatna :) 
			//string sveGreske = "";
			//foreach(string greska in rezultat.Errors.Select(er => er.Description))
			//{
			//	sveGreske += greska + System.Environment.NewLine;
			//}
		}

		public override async Task<StandardReplyMsg> LogIn(RegMsg request, ServerCallContext context)
		{
			if (!request.Login)
				return new StandardReplyMsg { Uspeh = false, Greska = "Nije poruka za login :/" };
			IdentityUser iu = await _uman.FindByNameAsync(request.Username);
			var rez = await _sim.PasswordSignInAsync(iu, request.Password, false, false);
			if (rez.Succeeded)
				return new StandardReplyMsg { Uspeh = true };
			else
				return new StandardReplyMsg { Uspeh = false, Greska = "Bad user/pass" };
		}

		public override async Task<EmptyMsg> LogOut(EmptyMsg request, ServerCallContext context)
		{
			await _sim.SignOutAsync();
			return new EmptyMsg();
		}
	}
}

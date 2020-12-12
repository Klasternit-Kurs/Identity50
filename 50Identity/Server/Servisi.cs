using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using grpcServisi;
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


		public override async Task<StandardReplyMsg> UnosKnjige(KnjigaMsg request, ServerCallContext context)
		{
			var knji = Baza.Knjigas.Where(k => k.Naziv == request.Naziv).FirstOrDefault();
			if (knji == null)
			{
				Knjiga knjiga = request;
				List<Autor> aut = new List<Autor>();
				request.Autori.ToList().ForEach(a =>
				{
					var autorBaza = Baza.Autors.Where(au => au.Ime == a.Ime).First();
					if (autorBaza == null)
						aut.Add(a);
					else
						aut.Add(autorBaza);
				});
				knjiga.Autori = aut;
				knji = Baza.Knjigas.Add(knjiga).Entity;
				await Baza.SaveChangesAsync();
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

using Google.Protobuf.WellKnownTypes;
using grpcServisi;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity50.Shared
{
	public class Korisnik : IdentityUser
	{
		public string Ime { get; set; }
		public string Prezime { get; set; }
		public string ImeIPrezime { get => $"{Ime} {Prezime}"; }
	}

	public class Zaposlen : Korisnik
	{
		public string Pozicija { get; set; }
	}

	public class Artikal
	{
		public static implicit operator ArtikalMsg(Artikal a)
			=> new ArtikalMsg { ID = a.ID, Naziv = a.Naziv};

		public static implicit operator Artikal(ArtikalMsg am)
			=> new Artikal { ID = am.ID, Naziv = am.Naziv };


		public int ID { get; set; }
		public string Naziv { get; set; }

		public List<Racun> Racuns { get; set; } = new List<Racun>();
		public List<RacunArtikal> RAs { get; set; } = new List<RacunArtikal>();
	}

	public class Racun
	{
		public static implicit operator RacunMsg(Racun r)
		{
			RacunMsg rm = new RacunMsg { Rbr = r.Rbr, Izdavanje = Timestamp.FromDateTime(r.VremeIzdavanja) };
			r.Artikals.ForEach(a => rm.Artikli.Add(a));
			return rm;
		}
		public static implicit operator Racun(RacunMsg rm)
		{
			Racun r = new Racun { Rbr = rm.Rbr, VremeIzdavanja = rm.Izdavanje.ToDateTime() };
			rm.Artikli.ToList().ForEach(a => r.Artikals.Add(a));
			return r;
		}
		public int Rbr { get; set; }
		public DateTime VremeIzdavanja { get; set; }

		public List<Artikal> Artikals { get; set; } = new List<Artikal>();
		public List<RacunArtikal> RAs { get; set; } = new List<RacunArtikal>();
	}

	public class RacunArtikal
	{
		public int RacunFK { get; set; }
		public Racun Racun { get; set; }

		public int ArtikalFK { get; set; }
		public Artikal Artikal { get; set; }

		public int Kolicina { get; set; }
	}
}

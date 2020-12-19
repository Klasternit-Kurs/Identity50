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

	public class Knjiga
	{
		public int ID { get; set; }
		public string Naziv { get; set; }

		public List<Autor> Autori { get; set; } = new List<Autor>();
		public ICollection<KnjigaAutor> KAs { get; set; }

		public static implicit operator KnjigaMsg(Knjiga k)
		{
			var km = new KnjigaMsg {ID = k.ID, Naziv = k.Naziv };
			k.Autori.ToList().ForEach(a => km.Autori.Add(a));
			return km;
		}

		public static implicit operator Knjiga(KnjigaMsg km)
		{
			var k = new Knjiga { ID = km.ID, Naziv = km.Naziv };
			km.Autori.ToList().ForEach(a => k.Autori.Add(a));
			return k;
		}
	}

	public class Autor
	{
		public int ID { get; set; }
		public string Ime { get; set; }

		public List<Knjiga> Knjige { get; set; } = new List<Knjiga>();
		public ICollection<KnjigaAutor> KAs { get; set; }

		public static implicit operator AutorMsg(Autor a)
		{
			var am = new AutorMsg { ID = a.ID, Ime = a.Ime };
			am.Knjige.ToList().ForEach(k => am.Knjige.Add(k));
			return am;
		}
		public static implicit operator Autor(AutorMsg am)
		{
			var a = new Autor { ID = am.ID, Ime = am.Ime };
			a.Knjige.ToList().ForEach(k => a.Knjige.Add(k));
			return a;
		}
	}

	public class KnjigaAutor
	{
		public DateTime Izdata { get; set; }

		public int Autor_FK { get; set; }
		public Autor Autor { get; set; }

		public int Knjiga_FK { get; set; }
		public Knjiga Knjiga { get; set; }
	}
}

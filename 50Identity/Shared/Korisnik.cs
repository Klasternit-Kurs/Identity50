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
}

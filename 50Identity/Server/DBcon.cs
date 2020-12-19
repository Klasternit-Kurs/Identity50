using Identity50.Shared;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity50.Server
{
    public class DBcon : ApiAuthorizationDbContext<IdentityUser>
    {
        public DBcon(DbContextOptions<DBcon> o,
            IOptions<OperationalStoreOptions> o2) : base(o, o2) { }

        public DbSet<Korisnik> Korisniks { get; set; }
        public DbSet<Zaposlen> Zaposlens { get; set; }

		public DbSet<Knjiga> Knjigas { get; set; }
		public DbSet<Autor> Autors { get; set; }

		public DbSet<KnjigaAutor> KnjigaAutors { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Knjiga>().HasKey(k => k.ID);
			builder.Entity<Autor>().HasKey(a => a.ID);

			builder.Entity<Knjiga>().HasIndex(k => k.Naziv).IsUnique();
			builder.Entity<Autor>().HasIndex(a => a.Ime).IsUnique();

			builder.Entity<Knjiga>().HasMany(k => k.Autori)
									.WithMany(a => a.Knjige)
									.UsingEntity<KnjigaAutor>
				(
					ka => ka.HasOne(ka => ka.Autor)
							.WithMany(a => a.KAs)
							.HasForeignKey(ka => ka.Autor_FK),
					ka => ka.HasOne(ka => ka.Knjiga)
							.WithMany(k => k.KAs)
							.HasForeignKey(ka => ka.Knjiga_FK),
					ka => ka.HasKey(ka => new { ka.Knjiga_FK, ka.Autor_FK})
				);

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "ZKLJ" },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = "ZKLJ" }
				);
		}
	}
}

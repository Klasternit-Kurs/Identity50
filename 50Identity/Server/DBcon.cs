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

		public DbSet<Artikal> Artikals { get; set; }
		public DbSet<Racun> Racuns { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<Artikal>().HasKey(a => a.ID);
			builder.Entity<Racun>().HasKey(r => r.Rbr);

			builder.Entity<Racun>().HasMany(r => r.Artikals)
								   .WithMany(a => a.Racuns)
								   .UsingEntity<RacunArtikal>
				(
					ra => ra.HasOne(ra => ra.Artikal)
							.WithMany(a => a.RAs)
							.HasForeignKey(ra => ra.ArtikalFK),
					ra => ra.HasOne(ra => ra.Racun)
							.WithMany(r => r.RAs)
							.HasForeignKey(ra => ra.RacunFK),
					ra => ra.HasKey(ra => new { ra.ArtikalFK, ra.RacunFK })
				);



			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "ZKLJ" },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = "ZKLJ" }
				);
		}
	}
}

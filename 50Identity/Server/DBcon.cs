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

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			builder.Entity<IdentityRole>().HasData(
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "Admin", NormalizedName = "ADMIN", ConcurrencyStamp = "ZKLJ" },
				new IdentityRole { Id = Guid.NewGuid().ToString(), Name = "User", NormalizedName = "USER", ConcurrencyStamp = "ZKLJ" }
				);
		}
	}
}

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace Identity50.Server
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddDbContext<DBcon>(options =>
				options.UseNpgsql(
						Configuration.GetConnectionString("Baza")));

			services.AddIdentity<IdentityUser, IdentityRole>()
				.AddUserManager<UserManager<IdentityUser>>()
				.AddSignInManager<SignInManager<IdentityUser>>()
				.AddRoleManager<RoleManager<IdentityRole>>()
				.AddRoles<IdentityRole>()
				.AddEntityFrameworkStores<DBcon>();

			services.AddIdentityServer()
				.AddApiAuthorization<IdentityUser, DBcon>(options => {
					options.IdentityResources["openid"].UserClaims.Add("name");
					options.ApiResources.Single().UserClaims.Add("name");
					options.IdentityResources["openid"].UserClaims.Add("role");
					options.ApiResources.Single().UserClaims.Add("role");
				});

			JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

			services.AddAuthentication()
				.AddIdentityServerJwt();

			services.AddGrpc();

			services.AddControllersWithViews();
			services.AddRazorPages();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseWebAssemblyDebugging();
			}
			else
			{
				app.UseExceptionHandler("/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseBlazorFrameworkFiles();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseIdentityServer();
			app.UseAuthentication();
			app.UseAuthorization();

			app.UseGrpcWeb(new GrpcWebOptions {DefaultEnabled=true});

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapGrpcService<Servisi>();
				endpoints.MapRazorPages();
				endpoints.MapControllers();
				endpoints.MapFallbackToFile("index.html");
			});
		}
	}
}

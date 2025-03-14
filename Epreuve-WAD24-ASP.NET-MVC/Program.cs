using Common.Repositories;
using Epreuve_WAD24_ASP.NET_MVC.Handlers;
using Epreuve_WAD24_ASP.NET_MVC.Handlers.ActionFilters;

namespace Epreuve_WAD24_ASP.NET_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpContextAccessor();

            builder.Services.AddDistributedMemoryCache();
                //options =>
                //{
                //    options.ConnectionString = builder.Configuration.GetConnectionString("Session-DB");
                //    options.SchemaName = "dbo";
                //    options.TableName = "EpreuveASP_Session";
                //}
                //);
            builder.Services.AddSession(
                options => {
                    options.Cookie.Name = "CookieEpreuveASP";
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                    options.IdleTimeout = TimeSpan.FromMinutes(10);
                });
            builder.Services.Configure<CookiePolicyOptions>(options => {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
                options.Secure = CookieSecurePolicy.Always;
            });

            //Ajout de notre service de sessionManager
            builder.Services.AddScoped<SessionManager>();



            //Ajout de Services 
            builder.Services.AddScoped<IUserRepository<BLL.Entities.Utilisateur>,BLL.Services.UserService>();
            builder.Services.AddScoped<IUserRepository<DAL.Entities.Utilisateur>, DAL.Services.UserService>();

            builder.Services.AddScoped<IJeuxRepository<BLL.Entities.Jeux>, BLL.Services.JeuxService>();
            builder.Services.AddScoped<IJeuxRepository<DAL.Entities.Jeux>, DAL.Services.JeuxService>();

            builder.Services.AddScoped<ITagRepository<BLL.Entities.Tag>, BLL.Services.TagService>();
            builder.Services.AddScoped<ITagRepository<DAL.Entities.Tag>, DAL.Services.TagService>();

            //builder.Services.AddScoped<IEtatRepository<BLL.Entities.Etat>, BLL.Services.EtatService>();
            //builder.Services.AddScoped<IEtatRepository<DAL.Entities.Etat>, DAL.Services.EtatService>();

            //builder.Services.AddScoped<IAssocierRepository<BLL.Entities.Associer>, BLL.Services.AssocierService>();
            //builder.Services.AddScoped<IAssocierRepository<DAL.Entities.Associer>, DAL.Services.AssocierService>();

            builder.Services.AddScoped<IEmpruntRepository<BLL.Entities.Emprunt>, BLL.Services.EmpruntService>();
            builder.Services.AddScoped<IEmpruntRepository<DAL.Entities.Emprunt>, DAL.Services.EmpruntService>();





            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSession();
            app.UseCookiePolicy();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
               name: "default",
               pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}

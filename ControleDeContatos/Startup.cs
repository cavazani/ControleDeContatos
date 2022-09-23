using ControleDeContatos.Data;
using Microsoft.EntityFrameworkCore;

namespace ControleDeContatos {
    public class Startup 
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get;  }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllersWithViews();
            services.AddEntityFrameworkSqlServer();
                services.AddDbContext<BancoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBase")));
        }

       



        public void Configure(WebApplication app, IWebHostEnvironment environment) 
        {
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment()) {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


        }


    }
}

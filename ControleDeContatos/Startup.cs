namespace ControleDeContatos {
    public class Startup 
    {
        public Startup(IConfiguration configuration) 
        {
            configuration = configuration;
        }

        public IConfiguration Configuration { get;  }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddControllersWithViews();
        
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

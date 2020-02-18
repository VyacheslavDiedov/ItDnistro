using IT_Dnistro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataBase;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace IT_Dnistro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            string connection = Configuration.GetConnectionString("ITDnistroDBConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();

            //Амнін роль
            // добавление ApplicationDbContext для взаимодействия с базой данных учетных записей
            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(connection));

            // добавление сервисов Idenity
            services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<DatabaseContext>();


            services.AddControllersWithViews();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
            services.AddControllers();
        }


        public static void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseDeveloperExceptionPage();
           
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();  
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Dnistro}/{id?}");
            });
        }
    }
}

//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Hosting;

//namespace IT_Dnistro
//{
//    public static class Program
//    {
//        public static void Main(string[] args)
//        {

//            //var host = CreateHostBuilder(args).Build();

//            //using (var scope = host.Services.CreateScope())
//            //{
//            //    var services = scope.ServiceProvider;
//            //    try
//            //    {
//            //        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
//            //        var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//            //        await RoleInitializer.InitializeAsync(userManager, rolesManager).ConfigureAwait(true);
//            //    }
//            //    catch (Exception ex)
//            //    {
//            //        var logger = services.GetRequiredService<ILogger<Program>>();
//            //        logger.LogError(ex, "An error occurred while seeding the database.");
//            //    }
//            //}

//            //host.Run();

//            CreateHostBuilder(args).Build().Run();
//        }


//        public static IHostBuilder CreateHostBuilder(string[] args) =>
//            Host.CreateDefaultBuilder(args)
//                .ConfigureWebHostDefaults(webBuilder =>
//                {
//                    webBuilder.UseStartup<Startup>();
//                });
//    }
//}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using DataBase;

namespace IT_Dnistro
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
                    var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await RoleInitializer.InitializeAsync(userManager, rolesManager).ConfigureAwait(true);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while seeding the database.");
                }
            }

            host.Run();

            // CreateHostBuilder(args).Build().Run();
        }




        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

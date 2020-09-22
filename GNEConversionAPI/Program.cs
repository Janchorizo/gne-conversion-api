using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GNEConversionAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // Heroku does not support exposing ports
                    // https://devcenter.heroku.com/articles/container-registry-and-runtime#dockerfile-commands-and-runtime
                    var port = Environment.GetEnvironmentVariable("PORT");
                    if (port != null)
                    { // Deploying on Heroku
                        webBuilder.UseStartup<Startup>()
                            .UseUrls("http://*:" + port);
                    } else
                    {
                        webBuilder.UseStartup<Startup>();
                    }
                    
                });
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Paramo.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the paramo API !");
            Console.WriteLine("Setting up runtime enviroment !");
            Console.WriteLine("Pelase Wait.......");
            Console.WriteLine("Pelase Wait.......");
            Console.WriteLine("Current Directory: " + Environment.CurrentDirectory);
            Console.WriteLine("Operating System: " + Environment.OSVersion);
            Console.WriteLine("Current Machine Name: " + Environment.MachineName);
            Console.WriteLine("System Directory: " + Environment.SystemDirectory);
            Console.WriteLine("User Name: " + Environment.UserName);
            Console.WriteLine("Enviroment Version: " + Environment.Version);

            CreateHostBuilder(args).Build().Run();           
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}

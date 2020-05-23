using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace WebStore
{
    public class Program
    {
        public static void Main(string[] args) =>  
            CreateHostBuilder(args)
            .Build()
            .Run();
        

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(opt => opt.AddIniFile("config.ini", optional: true, reloadOnChange: true)) //добавление ini файла
                .ConfigureWebHostDefaults(host =>
                {
                    host.UseStartup<Startup>();
                });
    }
}

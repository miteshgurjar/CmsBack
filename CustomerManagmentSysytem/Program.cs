using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;

namespace CustomerManagmentSysytem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var b = new {
            //    tc = 13,
            //    ak=9
            //};
            //try
            //{

            var configuration = new ConfigurationBuilder()
                 .AddJsonFile("appsettings.json").Build();
            Log.Logger = new LoggerConfiguration().CreateLogger();

            CreateWebHostBuilder(args).Build().Run();
           // }
           //finally
           // {

           //     Log.CloseAndFlush();
           // }
           
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

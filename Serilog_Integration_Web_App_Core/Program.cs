using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;


namespace Serilog_Integration_Web_App_Core
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigureLogger();
            Log.Information("Application started");
          

            try
            { 
            CreateHostBuilder(args).Build().Run(); // Original
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }



        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseSerilog();
                });

        public static void ConfigureLogger()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console(outputTemplate: "{Timestanp : yyyy-mm-dd} {MachineName} {ThreadId} {Message} {Exception} {NewLine}")
                .WriteTo.File(@"log.txt",outputTemplate: "{Timestanp : yyyy-mm-dd} {MachineName} {ThreadId} {Message} {Exception} {NewLine}") // creates file in application
                .Enrich.WithThreadId() // install package Serilog.Enrichers.Environment & Serilog.Enrichers.Thread
                .Enrich.WithMachineName()
                .CreateLogger();
                    
        }
    }
}

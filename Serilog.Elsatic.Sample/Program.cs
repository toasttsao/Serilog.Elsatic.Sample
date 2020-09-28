using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace Serilog.Elsatic.Sample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog((ctx,config) =>
                {
                    
                    config.MinimumLevel.Error();
                    config.WriteTo
                        //.DurableHttpUsingTimeRolledBuffers(
                        .DurableHttpUsingFileSizeRolledBuffers(
                            "http://localhost:8080/project_a",
                            "test",
                            1024*1024*1024,
                            true
                            
                        );

                })
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
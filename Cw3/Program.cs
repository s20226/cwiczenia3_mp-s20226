using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using System.IO;

namespace Cw3
{
    public class Program
    {


        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();

                });
        public static void Logg(string msg)
        {
            using (var w = File.AppendText("log.txt")) {
                w.WriteLine($"Error: {msg}");
            }
        }
    }
}

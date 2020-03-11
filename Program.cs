using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;

namespace MeowTeam
{
    public class Program
    {
        public static string url = "http://localhost:1533"; public static string configDir = "srvconfig";public static string configFile = "config.txt";public static string noteDir = "notes";
        public static void Main(string[] args)
        {
            if (!(Directory.Exists(configDir))) { IO.DirectoryCreate(configDir); }
            if (!(Directory.Exists(noteDir))) { IO.DirectoryCreate(noteDir); }
            if (!(File.Exists(configDir+"/"+configFile))) { IO.Write(url,configFile,configDir,false,true); }
            url = IO.ReadLine(configFile,1,configDir);
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>().UseUrls(url);
                });
    }
}
//
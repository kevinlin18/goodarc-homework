using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Web;

namespace Homework {
    public class Program {
        public static void Main(string[] args) {
            NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                })
                .ConfigureLogging(logging => {
                    //�M����L logger provide �p�w�] console (�@�g�]�w log �N���|�b console �W�X�{)
                    logging.ClearProviders();
                    //�]�w�̧C log ��X level
                    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
                })
                .UseNLog();
    }
}

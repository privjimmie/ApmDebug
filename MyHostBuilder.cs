using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Elastic.Apm.NetCoreAll;
using Microsoft.Extensions.DependencyInjection;

namespace ApmDebug
{
    internal class MyHostBuilder
    {
        public static IHostBuilder CreateHostBuilder(string[] args)
        {

            var hostBuilder = Host.CreateDefaultBuilder(args)
                .UseAllElasticApm()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<StartUp>();
                });


            return hostBuilder;
        }
    }
}

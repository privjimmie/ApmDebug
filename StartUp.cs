using Elastic.Apm.Api;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmDebug
{
    internal class StartUp : IHostedService
    {
        private readonly IHostApplicationLifetime _appLifetime;

        public StartUp(IHostApplicationLifetime appLifetime)
        {
            _appLifetime = appLifetime;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _appLifetime.ApplicationStarted.Register(() =>
            {
                Task.Run(async () =>
                {
                    Console.WriteLine($"APM.MaxBatchEventCount: {Elastic.Apm.Agent.Config.MaxBatchEventCount}");
                    Console.WriteLine($"APM.FlushInterval: {Elastic.Apm.Agent.Config.FlushInterval}");                  

                    try
                    {
                        await Elastic.Apm.Agent.Tracer.CaptureTransaction("TestName", ApiConstants.ActionExec, async () =>
                        {
                            Console.WriteLine("Simulate work here for 5 seconds");
                            await Task.Delay(5 * 1000);
                        });
                    }
                    catch (Exception exc)
                    {
                        throw;
                    }
                    finally
                    {
                        Console.WriteLine($"Call StopApplication()");
                        _appLifetime.StopApplication();
                    }
                });
            });

        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine($"StopAsync. Return CompletedTask");
            return Task.CompletedTask;
        }
    }
}

using Microsoft.Extensions.Hosting;

namespace ApmDebug
{
    internal class Program
    {
        static async Task<int> Main(string[] args)
        {
            EnvVariables.ElasticApmEnvironment = "myEnv";
            EnvVariables.ElasticApmServiceName = "myService";
            EnvVariables.ElasticApmServerUrl = "https://xxxxxxxxxxxxxxxx.apm.eu-west-1.aws.cloud.es.io:443";
            EnvVariables.ElasticApmSecretToken = "secret";
            EnvVariables.ElasticApmMaxBatchEventCount =1;
            EnvVariables.ElasticApmFlushInterval = 1;

            try
            {
                var host = MyHostBuilder.CreateHostBuilder(args);
                await host.RunConsoleAsync();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Host terminated unexpectedly");
            }
            finally
            {
                Console.WriteLine("Exiting..");
            }

            return Environment.ExitCode;
        }
    }
}
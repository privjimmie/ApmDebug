using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApmDebug
{
    internal static class EnvVariables
    {
        public static string ElasticApmServerUrl
        {
            get { return Environment.GetEnvironmentVariable("ElasticApm:ServerUrl"); }
            set { Environment.SetEnvironmentVariable("ElasticApm:ServerUrl", value); }
        }

        public static string ElasticApmSecretToken
        {
            get { return Environment.GetEnvironmentVariable("ElasticApm:SecretToken"); }
            set { Environment.SetEnvironmentVariable("ElasticApm:SecretToken", value); }
        }

        public static string ElasticApmServiceName
        {
            get { return Environment.GetEnvironmentVariable("ElasticApm:ServiceName"); }
            set { Environment.SetEnvironmentVariable("ElasticApm:ServiceName", value); }
        }

        public static string ElasticApmEnvironment
        {
            get { return Environment.GetEnvironmentVariable("ElasticApm:Environment"); }
            set { Environment.SetEnvironmentVariable("ElasticApm:Environment", value); }
        }

        public static int ElasticApmMaxBatchEventCount
        {
            get { return int.Parse(Environment.GetEnvironmentVariable("ElasticApm:MaxBatchEventCount") ?? "-1"); }
            set { Environment.SetEnvironmentVariable("ElasticApm:MaxBatchEventCount", value.ToString()); }
        }

        public static int ElasticApmFlushInterval
        {
            get { return int.Parse(Environment.GetEnvironmentVariable("ElasticApm:FlushInterval") ?? "-1"); }
            set { Environment.SetEnvironmentVariable("ElasticApm:FlushInterval", value.ToString()); }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using App.Metrics;
using App.Metrics.AspNetCore;
using App.Metrics.Formatters.Prometheus;
using App.Metrics.Formatters;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace VideoRentStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseMetrics()
                .UseStartup<Startup>();

        //public static IMetricsRoot Metrics { get; set; }

        //public static IWebHost BuildWebHost(string[] args)
        //{
        //    Metrics = AppMetrics.CreateDefaultBuilder()
        //            .OutputMetrics.AsPrometheusPlainText()
        //            .OutputMetrics.AsPrometheusProtobuf()
        //            .Build();

        //    return WebHost.CreateDefaultBuilder(args)
        //                    .ConfigureMetrics(Metrics)
        //                    .UseMetrics(
        //                        options =>
        //                        {
        //                            options.EndpointOptions = endpointsOptions =>
        //                            {
        //                                endpointsOptions.MetricsTextEndpointOutputFormatter = Metrics.OutputMetricsFormatters.GetType<MetricsPrometheusTextOutputFormatter>();
        //                                endpointsOptions.MetricsEndpointOutputFormatter = Metrics.OutputMetricsFormatters.GetType<MetricsPrometheusProtobufOutputFormatter>();
        //                            };
        //                        })
        //                    .UseStartup<Startup>()
        //                    .Build();
        //}

        //public static void Main(string[] args) { BuildWebHost(args).Run(); }
    }
}

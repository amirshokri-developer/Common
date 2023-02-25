using Common.Logging.Serilog.Enrichers;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Formatting.Elasticsearch;


namespace Common.Logging.Serilog;

public static class SerilogExtensions
{
    
    public static IHostBuilder AddSerilogConsole(this IHostBuilder builder , IHostEnvironment env)
    {
        
        Log.Logger = ConfigureConsoleLogging(env)
            .WriteTo.Console()
            .CreateLogger();
        
        builder.UseSerilog();

        return builder;

    }

    private static LoggerConfiguration ConfigureConsoleLogging(IHostEnvironment env)
    {
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        return  new LoggerConfiguration()
            .MinimumLevel.Information()
            .Enrich.FromLogContext()
            .Enrich.With<ActivityEnricher>()
            .Enrich.WithProperty("Environment", environment)
            .Enrich.WithProperty("ApplicationName", env.ApplicationName);
        
    }
}
using Serilog;
using Serilog.Events;

namespace Vktg;

internal class Program
{
    static void Main(string[] args)
    {
        Log.Logger = CreateLogger();
        Log.Logger.Information("Vktg started");

        Console.ReadKey();
    }

    static ILogger CreateLogger()
    {
        var logFilePath = Path.Combine(Environment.CurrentDirectory, "vktg-.log");
        var logLevel = LogEventLevel.Verbose;
        var logOutputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff} [{Level:u3}] {Message:lj}{NewLine}{Exception}";

        return new LoggerConfiguration()
            .WriteTo.Console(logLevel, logOutputTemplate)
            .WriteTo.File(logFilePath, logLevel, logOutputTemplate, rollingInterval: RollingInterval.Day)
            .Enrich.FromLogContext()
            .CreateLogger();
    }
}

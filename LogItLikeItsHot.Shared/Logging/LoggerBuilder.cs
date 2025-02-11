using Serilog.Core;
using Serilog;
using Destructurama;
using Serilog.Enrichers;

namespace LogItLikeItsHot.Shared.Logging
{
    public class LoggerBuilder
    {
        public static ILogger BuildLogger(string seqApiKey, string appName)
        {
            // todo : 3d. control the minimum log level remotely, tip: LoggingLevelSwitch
            var levelSwitch = new LoggingLevelSwitch(Serilog.Events.LogEventLevel.Information);

            var loggerConfig = new LoggerConfiguration()
                .MinimumLevel.ControlledBy(levelSwitch)
                .Destructure.UsingAttributes()
                .Enrich.FromLogContext()
                .WriteTo.Console()
            // todo : 1c. add seq sink
                .WriteTo.Seq("http://localhost:5341", apiKey: seqApiKey, controlLevelSwitch: levelSwitch);

            // todo : 3a. add enrichers
            // log appName as a property 'Application'
            // log the machine name
            // log the user name that the application is running under
            loggerConfig
                .Enrich.WithProperty("Application", appName)
                .Enrich.WithMachineName()
                .Enrich.WithEnvironmentUserName();

            Log.Logger = loggerConfig.CreateLogger();

            return Log.Logger;
        }
    }
}

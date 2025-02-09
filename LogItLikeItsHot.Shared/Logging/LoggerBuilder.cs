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
            var loggerConfig = new LoggerConfiguration()
                .Destructure.UsingAttributes()
                .Enrich.FromLogContext()
                .WriteTo.Console();
            // todo : 1c. add seq sink

            Log.Logger = loggerConfig.CreateLogger();

            return Log.Logger;
        }
    }
}

using LogItLikeItsHot.Barista.Features;
using LogItLikeItsHot.Barista.Mediatr;
using LogItLikeItsHot.Shared.Logging;
using MediatR;
using Serilog;
using SerilogTracing;

namespace LogItLikeItsHot.Barista
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoggerBuilder.BuildLogger("yMblo58lvf2SWwxAamYJ", "Barista api");

            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetMenuHandler).Assembly);
            });

            // todo : 2a. integrate Serilog with .NET
            builder.Host.UseSerilog();

            // todo : 2c. register the Mediatr behavior
            builder.Services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));

            // todo: 4b. tracing setup api, tip: you need an activity listener to instrument the AspNetCoreRequests


            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}

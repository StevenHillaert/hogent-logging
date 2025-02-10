using LogItLikeItsHot.Barista.Features;
using LogItLikeItsHot.Shared.Logging;
using MediatR;
using Serilog;

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

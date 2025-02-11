using MediatR;
using Serilog.Context;
using Serilog.Events;
using Serilog;

namespace LogItLikeItsHot.Barista.Mediatr
{
    // todo : 2b. create a Mediatr logging behavior
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            string requestType = typeof(TRequest).Name;
            TResponse response;

            // todo: 4c. tracing pipeline, tip: use the Serilog to start an activity


            using (LogContext.PushProperty("RequestType", requestType))
            using (LogContext.PushProperty("Request", request, true))
            {
                // log start of every request
                Log.Information("Start {RequestType}");

                // time the handler and log if time exceeds threshold
                using (Log.Logger.BeginTimedOperation("Timing handler", warnIfExceeds: TimeSpan.FromMilliseconds(400)))
                {
                    response = await next();
                }

                // log end of every request
                Log.Information("Finished {RequestType}");
            }

            return response;
        }
    }
}

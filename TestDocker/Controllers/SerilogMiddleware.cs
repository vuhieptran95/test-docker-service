using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Serilog.Context;

namespace TestDocker.Controllers
{
    public class SerilogMiddleware: IMiddleware
    {
        public Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            using (LogContext.PushProperty("Service", "TestDocker"))
            {
                return next(context);
            }
        }
    }
}
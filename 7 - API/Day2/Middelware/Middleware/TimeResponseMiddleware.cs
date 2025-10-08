
namespace Middelware.Middleware
{
    public class TimeResponseMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            Console.WriteLine($"[Start Req]:{DateTime.Now}");
            await next(context);
            Console.WriteLine($"[End Req]: {DateTime.Now}");
            Console.WriteLine($"[Req Duration]: ");
        }
    }
}

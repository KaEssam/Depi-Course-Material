namespace Middelware.Middleware
{
    public class LogMiddleware
    {
        private readonly RequestDelegate _next;

        public LogMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task InvokeAsync(HttpContext context)
        {
            Console.WriteLine($"[log]req: {context.Request.Method}");
            await _next(context);
            Console.WriteLine($"[log]res status: {context.Response.StatusCode}");
        }
    }

    public static class LogExtension
    {
        public static IApplicationBuilder useLog(this IApplicationBuilder app)
        {
            return app.UseMiddleware<LogMiddleware>();
        }
    }
}

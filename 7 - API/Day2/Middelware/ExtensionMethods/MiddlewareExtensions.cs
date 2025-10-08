using Middelware.Middleware;

namespace Middelware.ExtensionMethods
{
    public static class MiddlewareExtensions
    {
  
        //    public static IApplicationBuilder useLog(this IApplicationBuilder app)
        //    {
        //        return app.UseMiddleware<LogMiddleware>();
        //    }




        public static IApplicationBuilder TimeResonse(this IApplicationBuilder app)
        {
            return app.UseMiddleware<TimeResponseMiddleware>();
        }
    }
}

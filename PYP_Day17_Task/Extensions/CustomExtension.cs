using PYP_Day17_Task.Middlewares;

namespace PYP_Day17_Task.Extensions
{
    public static class CustomExtension
    {
        public static IApplicationBuilder CustomExtensionMiddleware(this IApplicationBuilder app)
        {
            
            return app.UseMiddleware<ResponseEditingMiddleware>();
        }
    }
}

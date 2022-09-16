using System.Globalization;
using System.Text.Json;
using PYP_Day17_Task.Models;

namespace PYP_Day17_Task.Middlewares
{
    public class ResponseEditingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IConfiguration _configurationManager;

        public ResponseEditingMiddleware(RequestDelegate next, IConfiguration configurationManager)
        {
            _next = next;
            _configurationManager = configurationManager;
        }

        public async Task Invoke(HttpContext context)
        {


            var info = _configurationManager.GetSection("CompanyInfo").GetChildren();
            foreach (var item in info)
            {
                context.Response.Headers.Add(item.Key, item.Value);
            }
            await _next.Invoke(context);

        }

    }
}

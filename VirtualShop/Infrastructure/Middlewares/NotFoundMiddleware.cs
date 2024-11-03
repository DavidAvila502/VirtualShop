using System.Text.Json;

namespace VirtualShop.Infrastructure.Middlewares
{
    public class NotFoundMiddleware
    {

        private readonly RequestDelegate _next;


        public NotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context) {

            await _next(context);


            if (context.Response.StatusCode == 404)
            {
                context.Response.ContentType = "application/json";
                
                dynamic content = new { error = "Error: 404 page not found " };

                string jsonContent = JsonSerializer.Serialize(content);

                await context.Response.WriteAsync(jsonContent);
            }
        }
    }
}

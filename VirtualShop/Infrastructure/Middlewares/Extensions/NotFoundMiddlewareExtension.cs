namespace VirtualShop.Infrastructure.Middlewares.Extensions
{
    public static class NotFoundMiddlewareExtension
    {
        public static IApplicationBuilder UseNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<NotFoundMiddleware>();
        
        }
    }
}

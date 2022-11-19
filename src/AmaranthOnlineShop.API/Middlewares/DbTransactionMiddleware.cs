using AmaranthOnlineShop.Infrastructure.Persistence.Contexts;

namespace AmaranthOnlineShop.API.Middlewares
{
    public class DbTransactionMiddleware
    {
        private readonly RequestDelegate _next;

        public DbTransactionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, AmaranthOnlineShopDbContext context)
        {
            if (httpContext.Request.Method == HttpMethod.Get.Method)
            {
                await _next(httpContext);
                return;
            }

            await using var transaction = await context.Database.BeginTransactionAsync();

            await _next(httpContext);

            await context.Database.CommitTransactionAsync();
        }
    }
}
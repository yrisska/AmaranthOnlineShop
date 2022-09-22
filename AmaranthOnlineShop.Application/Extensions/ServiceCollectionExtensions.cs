using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace AmaranthOnlineShop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddMediatR(assembly);

            return services;
        }
    }
}

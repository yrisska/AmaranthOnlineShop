using AmaranthOnlineShop.Application.Common.Interfaces;
using AmaranthOnlineShop.Infrastructure.CloudStorage.Repositories;
using AmaranthOnlineShop.Infrastructure.Payment;
using AmaranthOnlineShop.Infrastructure.Persistence.Contexts;
using AmaranthOnlineShop.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Stripe;

namespace AmaranthOnlineShop.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureLayer(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AmaranthOnlineShopDbContext>(optionBuilder =>
            {
                optionBuilder.UseSqlServer(configuration.GetConnectionString("AmaranthOnlineShopConnection"));
            });

            services.AddScoped<IRepository, EFCoreRepository>();
            services.AddScoped<IPaymentProvider, StripePaymentProvider>();
            services.AddTransient<ICloudStorage, AzureStorage>();

            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];

            return services;
        }
    }
}
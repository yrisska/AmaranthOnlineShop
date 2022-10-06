using AmaranthOnlineShop.Application;
using AmaranthOnlineShop.Application.Common.Models;
using AmaranthOnlineShop.Application.Extensions;
using AmaranthOnlineShop.Infrastructure.Persistence.Extensions;
using System.Text.Json.Serialization;

namespace AmaranthOnlineShop.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructureLayer(builder.Configuration);
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            builder.Services.AddApplicationLayer();
            builder.Services.AddAutoMapper(typeof(ApplicationAssemblyMarker));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}

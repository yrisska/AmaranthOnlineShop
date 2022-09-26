﻿using AmaranthOnlineShop.Application;
using AmaranthOnlineShop.Application.Extensions;
using AmaranthOnlineShop.Infrastructure.Persistence.Contexts;
using AmaranthOnlineShop.Infrastructure.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AmaranthOnlineShop.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddInfrastructureLayer(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddApplicationLayer();
            builder.Services.AddAutoMapper(typeof(ApplicationAssemblyMarker));
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
        }
    }
}
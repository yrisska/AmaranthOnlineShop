﻿using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;
using AmaranthOnlineShop.Application.Common.Behaviors;
using FluentValidation;

namespace AmaranthOnlineShop.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplicationLayer(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddValidatorsFromAssembly(assembly);
            services.AddMediatR(assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

            return services;
        }
    }
}

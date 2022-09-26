using AmaranthOnlineShop.API.Extensions;
using AmaranthOnlineShop.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AmaranthOnlineShop.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.AddServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();


            app.MapControllers();

            await app.RunAsync();
        }
    }
}
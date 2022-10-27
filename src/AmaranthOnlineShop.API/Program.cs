using AmaranthOnlineShop.API.Extensions;

namespace AmaranthOnlineShop.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.AddServerHeader = false;
                serverOptions.AllowResponseHeaderCompression = true;
                serverOptions.Limits.KeepAliveTimeout = TimeSpan.FromMinutes(2);
            });
            // Add services to the container.

            builder.AddServices();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseExceptionHandling();
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.UseDbTransaction();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
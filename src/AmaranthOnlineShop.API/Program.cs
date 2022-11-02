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

            builder.AddServices();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(options =>
                {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "API");
                    options.OAuthClientId(app.Configuration["Auth0:ClientId"]);
                    options.OAuthUsePkce();
                });
                app.UseCors(x => x
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                );
            }

            
            app.UseExceptionHandling();
            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseDbTransaction();

            app.MapControllers();

            await app.RunAsync();
        }
    }
}
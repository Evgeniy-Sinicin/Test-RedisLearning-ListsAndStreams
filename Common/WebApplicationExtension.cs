using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

public static class WebApplicationExtension
{
    extension(WebApplication)
    {
        public static void Run()
        {
            var builderOptions = new WebApplicationOptions{ ContentRootPath = AppDomain.CurrentDomain.BaseDirectory };
            var builder = WebApplication.CreateBuilder(builderOptions);
            
            builder.Services.Configure<AppOptions>(builder.Configuration);
            var appOptions = builder.Configuration.Get<AppOptions>()!;

            builder.Services.AddControllers();
            builder.Services.AddRouting();
            builder.Services.AddSingleton<IConnectionMultiplexer>(_ => ConnectionMultiplexer.Connect(appOptions.Redis.Address));
            builder.Services.AddSingleton<RedisService>();

            var app = builder.Build();
            app.MapControllers();
            app.MapControllerRoute(appOptions.Routing.Name, appOptions.Routing.Pattern, appOptions.Routing.Defaults);
            app.Run();
        }
    }
}
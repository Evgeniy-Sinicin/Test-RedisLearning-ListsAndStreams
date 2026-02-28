using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

public static class WebApplicationExtension
{
    extension(WebApplication)
    {
        public static void Run()
        {
            var builderOptions = new WebApplicationOptions{ ContentRootPath = AppDomain.CurrentDomain.BaseDirectory };
            var builder = WebApplication.CreateBuilder(builderOptions);
            builder.Services.AddControllers();
            builder.Services.AddRouting();
            builder.Services.Configure<RoutingOptions>(builder.Configuration.GetSection(RoutingOptions.SectionName));

            var app = builder.Build();
            var routing = app.Services.GetRequiredService<IOptions<RoutingOptions>>().Value;
            app.MapControllers();
            app.MapControllerRoute(routing.Name, routing.Pattern);
            app.Run();
        }
    }
}
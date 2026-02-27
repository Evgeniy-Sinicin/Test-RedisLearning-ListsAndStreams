using Microsoft.Extensions.Options;

var contentRootPath = Path.GetFullPath("../Common.Configuration");
var builder = WebApplication.CreateBuilder(new WebApplicationOptions{ ContentRootPath = contentRootPath});
builder.Services.AddControllers();
builder.Services.AddRouting();
builder.Services.Configure<RoutingOptions>(builder.Configuration.GetSection(RoutingOptions.SectionName));

var app = builder.Build();
var routing = app.Services.GetRequiredService<IOptions<RoutingOptions>>().Value;
app.MapControllers();
app.MapControllerRoute(routing.Name, routing.Pattern);
app.Run();

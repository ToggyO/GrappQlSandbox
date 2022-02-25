using WebApplication1;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.ConfigureMiddleware(app, builder.Environment);
startup.ConfigureEndpoints(app);

app.Run();

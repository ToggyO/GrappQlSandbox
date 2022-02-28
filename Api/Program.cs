using Api;

using Common.Settings;

using Domain.Models.Users;

using Infrastructure.Factories;

using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.ConfigureMiddleware(app, builder.Environment);
startup.ConfigureEndpoints(app);

// TODO: delete
var jwtSettings = app.Services.GetRequiredService<IOptions<JwtSettings>>();
var tokenDto = new JwtTokensFactory(jwtSettings).CreateToken(new User { Id = 1, Name = "Oleg", Email = "asd@asd.com" }, "");
Console.WriteLine(tokenDto.AccessToken);
//

app.Run();

using System.Text;

using Common.Settings;

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Api.Extensions;

public static class ServiceCollectionExtensions
{
	/// <summary>
	/// Add authentication and authorization an application services.
	/// </summary>
	/// <param name="services">Instance of <see cref="IServiceCollection"/>.</param>
	/// <param name="configuration">Application configuration.</param>
	/// <param name="serviceLifetime">Service lifetime enumeration.</param>
	public static void AddAuthServices(this IServiceCollection services,
		IConfiguration configuration)
	{
		var jwtSettingsSection = configuration.GetSection("JwtSettings");

		services.Configure<JwtSettings>(jwtSettingsSection);
		var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

		services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			.AddJwtBearer(o =>
			{
				o.TokenValidationParameters = new TokenValidationParameters
				{
					ClockSkew = TimeSpan.Zero,

					ValidateAudience = true,
					ValidAudience = jwtSettings.Audience,

					ValidateIssuer = true,
					ValidIssuer = jwtSettings.Issuer,

					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.PrivateKey)),
					ValidateIssuerSigningKey = true,

					// To allow return custom response for expired token
					ValidateLifetime = false
				};
			});

		services.AddAuthorization();
	}
}

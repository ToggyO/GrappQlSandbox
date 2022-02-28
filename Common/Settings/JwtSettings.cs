using System.Diagnostics.CodeAnalysis;

namespace Common.Settings;

public class JwtSettings
{
	public string PrivateKey { set; get; }

	public int AccessTokenExpiresInMinutes { set; get; }
	
	public int RefreshTokenExpiresInMinutes { set; get; }
	
	public string Issuer { set; get; }

	public string Audience { set; get; }
}

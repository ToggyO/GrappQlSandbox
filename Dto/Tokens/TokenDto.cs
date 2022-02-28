using System;

namespace Dto.Tokens;

public class TokenDto
{
	public string? AccessToken { get; set; }

	public DateTime AccessTokenExpire { get; set; }

	public string? RefreshToken { get; set; }

	public DateTime RefreshTokenExpire { get; set; }
}

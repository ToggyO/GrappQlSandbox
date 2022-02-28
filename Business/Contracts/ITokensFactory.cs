using System.Security.Claims;

using Business.Enums;

using Domain.Models.Users;

using Dto.Tokens;

namespace Business.Contracts;

/// <summary>
/// Authentication tokens factory.
/// </summary>
public interface ITokensFactory
{
	/// <summary>
	/// Creates authentication tokens.
	/// </summary>
	/// <param name="user">User model.</param>
	/// <param name="permissions">User permissions, joined by `,`.</param>
	/// <returns></returns>
	TokenDto CreateToken(User user, string permissions = "");

	/// <summary>
	/// Validates authentication token.
	/// </summary>
	/// <param name="token">Authentication token.</param>
	/// <param name="principal">Instance of <see cref="ClaimsPrincipal"/>.</param>
	/// <returns></returns>
	TokenStatus ValidateToken(string token, out ClaimsPrincipal principal);
}

using System.Security.Claims;

namespace Domain.Contracts;

public interface IProvideClaimsPrincipal
{
	ClaimsPrincipal User { get; set; }
}
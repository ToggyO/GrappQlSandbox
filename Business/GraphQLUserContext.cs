using System.Security.Claims;

using Domain.Contracts;

namespace Business;

public class GraphQLUserContext : Dictionary<string, object>, IProvideClaimsPrincipal
{
	public ClaimsPrincipal User { get; set; }
}
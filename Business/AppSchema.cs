using GraphQL.Types;

using Microsoft.Extensions.DependencyInjection;

namespace Business;

public class AppSchema : Schema
{
	public AppSchema(IServiceProvider serviceProvider) : base(serviceProvider)
	{
		Query = serviceProvider.GetRequiredService<AppQuery>();
		Mutation = serviceProvider.GetRequiredService<AppMutations>();
	}
}


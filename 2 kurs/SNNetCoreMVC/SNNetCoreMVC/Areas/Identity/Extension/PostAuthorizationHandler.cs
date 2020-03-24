using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SNNetCoreMVC
{
	public class PostAuthorizationHandler : AuthorizationHandler<TimeAccessRequirement, Post>
	{
		protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, 
														TimeAccessRequirement requirement, 
														Post resource)
		{
			if (DateTime.Now.Hour >= 9 && DateTime.Now.Hour < 18)
			{
				context.Succeed(requirement);
			}

			return Task.CompletedTask;
		}
	}
}

using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Identity.Authorization;

namespace ProjectAPI.Authorization
{
  public class RoleClaimRequirmentHandler : AuthorizationHandler<RoleClaimRequirement>
  {
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RoleClaimRequirement requirement)
    {

      if (context.User.HasClaim(ClaimTypes.Role, requirement.Role))
        context.Succeed(requirement);

      return Task.CompletedTask;
    }
  }

}

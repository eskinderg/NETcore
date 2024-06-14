using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using ProjectAPI.Identity.Authorization;

namespace ProjectAPI.Authorization
{
  public class EmailRoleClaimRequirmentHandler : AuthorizationHandler<EmailRoleClaimRequirement>
  {
    // public Task HandleAsync(AuthorizationHandlerContext context)
    // {
    //   return this.HandleRequirementAsync(context, new RoleClaimRequirement("asdf"));
    // }

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRoleClaimRequirement requirement)
    {
      System.Console.Write(context.User.HasClaim(ClaimTypes.Email, requirement.Email) + "\n" + requirement.Email + "\n" + context.User.GetLoggedInUserEmail());
      if (context.User.HasClaim(ClaimTypes.Email, requirement.Email))
        context.Succeed(requirement);

      return Task.CompletedTask;
    }
  }

}

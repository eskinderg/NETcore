using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Identity.Authorization
{
  public class RoleClaimRequirement : IAuthorizationRequirement
  {
    public string Role { get; set; }
    public RoleClaimRequirement(string role)
    {
      Role = role;
    }
  }
}

using Microsoft.AspNetCore.Authorization;

namespace ProjectAPI.Identity.Authorization
{
  public class EmailRoleClaimRequirement : IAuthorizationRequirement
  {

    public string Email { get; set; }

    public EmailRoleClaimRequirement(string email)
    {
      Email = email;
    }

  }
}

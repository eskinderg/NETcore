
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;

namespace ProjectAPI.Identity.Authorization
{
    public class ProjectJwtBearerEvents : JwtBearerEvents {
        
        public override Task Challenge(JwtBearerChallengeContext context){

            context.HandleResponse();

            var payload = new JObject
            {
                ["error"] = context.Error,
                ["error_description"] = context.ErrorDescription,
                ["error_uri"] = context.ErrorUri
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 401;

            return context.Response.WriteAsync(payload.ToString()); 
        }

        public override Task AuthenticationFailed(AuthenticationFailedContext context)
        {
            return base.AuthenticationFailed(context);
        }
    }
}

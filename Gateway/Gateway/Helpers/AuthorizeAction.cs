using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.Extensions.Primitives;
using Gateway.Logger;
using Google.Cloud.Logging.Type;

namespace Gateway.Helpers
{
    public class AuthorizeAction : IAuthorizationFilter
    {
        readonly Claim _claim;
        private readonly IAuthHelper _auth;
        private readonly ILoggerService _loggerService;

        public AuthorizeAction(Claim claim, IAuthHelper auth, ILoggerService loggerService)
        {
            _claim = claim;
            _auth = auth;
            _loggerService = loggerService;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("Authorization", out StringValues token);
            if (token != default(StringValues))
            {
                if (_auth.ValidateCurrentToken(token))
                {
                    var roleClaim = _auth.GetClaim(token, "Role");
                    var roleArray = _claim.Value.Split(',');
                    foreach (var role in roleArray)
                    {
                        if (role == roleClaim)
                            return;
                    }
                }
                _loggerService.WriteLog("Niste autorizovani", null, LogSeverity.Error);
                context.Result = new UnauthorizedResult();
            }
            return;
        }
    }
}

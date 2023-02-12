using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Gateway.Helpers
{
    public class AuthRoleAttribute : TypeFilterAttribute
    {
        public AuthRoleAttribute(string claimType, string claimValue) : base(typeof(AuthorizeAction))
        {
            Arguments = new object[] { new Claim(claimType, claimValue) };
        }
    }
}

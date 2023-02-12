namespace Gateway.Helpers
{
    public interface IAuthHelper
    {

        public bool ValidateCurrentToken(string token);

        public string GetClaim(string token, string claimType);
    }
}

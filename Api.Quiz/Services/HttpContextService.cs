using System.Security.Claims;

namespace Api.Quiz.Services
{
    public class HttpContextService
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ClaimsPrincipal? UserClaims => _contextAccessor.HttpContext?.User;

        public Guid? GetAccountId()
        {
            var userClaims = UserClaims;

            if(userClaims == null)
                return null;

            var claimNameIdeftifier = userClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
            if (claimNameIdeftifier == null)
                return null;

            var result = Guid.TryParse(claimNameIdeftifier.Value, out Guid accountId);
            if(result == false)
                return null;

            return accountId;
        }
    }
}

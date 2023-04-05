using Application.Quiz.Services;
using System.Security.Claims;

namespace Api.Quiz.Services
{
    public class HttpContextService : ICurrentIdentity
    {
        private readonly IHttpContextAccessor _contextAccessor;

        public HttpContextService(IHttpContextAccessor contextAccessor)
        {
            _contextAccessor = contextAccessor;
        }

        public ClaimsPrincipal? UserClaims => _contextAccessor.HttpContext?.User;

        public Guid? AccountId
        {
            get
            {
                var userClaims = UserClaims;

                if (userClaims == null)
                    return null;

                var claimNameIdeftifier = userClaims.FindFirst(c => c.Type == ClaimTypes.NameIdentifier);
                if (claimNameIdeftifier == null)
                    return null;

                var result = Guid.TryParse(claimNameIdeftifier.Value, out Guid accountId);
                if (result == false)
                    return null;

                return accountId;
            }
        }
    }
}

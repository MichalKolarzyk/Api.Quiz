using Application.Quiz.Authentications;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Infrastructure.Quiz.Authentications
{
    class JwtTokenService : IAuthenticationTokenService
    {
        private readonly IAuthenticationSettings _authenticationSettings;

        public JwtTokenService(IAuthenticationSettings authenticationSettings)
        {
            _authenticationSettings = authenticationSettings;
        }

        public string GenerateToken(GenerateTokenData data)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, data.NameIdentifier),
                new Claim(ClaimTypes.Name, data.Name),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_authenticationSettings.Key));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = data.Expires;

            var token = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: cred);
            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }
    }
}

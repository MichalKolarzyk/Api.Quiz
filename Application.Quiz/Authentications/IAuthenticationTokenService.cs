namespace Application.Quiz.Authentications
{
    public interface IAuthenticationTokenService
    {
        string GenerateToken(GenerateTokenData data);
    }
}
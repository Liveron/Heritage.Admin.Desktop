using L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Model;

public class TokenRepository : ITokenRepository
{
    public TokensDto Tokens { get; private set; } = new();

    public void SaveTokens(TokensDto tokens)
    {
        Tokens = tokens;
    }

    public TokensDto GetTokens()
    {
        return Tokens;
    }
}

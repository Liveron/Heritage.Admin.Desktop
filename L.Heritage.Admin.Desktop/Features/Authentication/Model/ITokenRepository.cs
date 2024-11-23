using L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Model;

public interface ITokenRepository
{
    public void SaveTokens(TokensDto tokens);
    public TokensDto GetTokens();
}

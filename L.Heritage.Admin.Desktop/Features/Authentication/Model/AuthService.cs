using L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;
using L.Heritage.Admin.Desktop.Shared.Api;
using Microsoft.IdentityModel.JsonWebTokens;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Model;

public class AuthService(ApiUtils apiUtils, AuthStore authStore, ITokenRepository tokenRepository)
{
    private readonly ApiUtils _apiUtils = apiUtils;
    private readonly AuthStore _authStore = authStore;
    private readonly ITokenRepository _tokenRepository = tokenRepository;

    public async Task<bool> Login(LoginDto loginDto)
    {
        TokensDto? tokens = await _apiUtils.PostAsync<TokensDto, LoginDto>("/authentication/login", loginDto);

        if (tokens == null) return false;

        bool isAuthenticated = CheckIfAdmin(tokens.AccessToken);

        if (isAuthenticated)
        {
            _tokenRepository.SaveTokens(tokens);
            _authStore.IsAuthenticated = true;
        }

        return _authStore.IsAuthenticated;
    }

    private static bool CheckIfAdmin(string accessToken)
    {
        var tokenHandler = new JsonWebTokenHandler();
        JsonWebToken token = tokenHandler.ReadJsonWebToken(accessToken);
        return true;
    }
}

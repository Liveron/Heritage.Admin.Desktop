using L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;
using L.Heritage.Admin.Desktop.Features.Authentication.Model;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace L.Heritage.Admin.Desktop.Features.Authentication.Api;

public class AuthenticationHandler(ITokenRepository tokenRepository, IHttpClientFactory httpClientFactory) : DelegatingHandler
{
    private readonly ITokenRepository _tokenRepository = tokenRepository;
    private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

    protected async override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken cancellationToken)
    {
        string accessToken = _tokenRepository.GetTokens().AccessToken;

        if (string.IsNullOrWhiteSpace(accessToken))
            throw new InvalidOperationException("Access token is missing");

        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

        try
        {
            HttpResponseMessage response = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException exception) when (IsUnauthorizedRequest(exception, request.RequestUri))
        {
            string newAccessToken = await RefreshAccessToken(cancellationToken);

            request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", newAccessToken);
            HttpResponseMessage retryResponse = await base.SendAsync(request, cancellationToken).ConfigureAwait(false);
            return retryResponse.EnsureSuccessStatusCode();
        }
    }

    private async Task<string> RefreshAccessToken(CancellationToken cancellationToken)
    {
        using HttpClient client = _httpClientFactory.CreateClient("Default");
        HttpResponseMessage response = await client.PostAsJsonAsync(
            "token", _tokenRepository.GetTokens(), cancellationToken).ConfigureAwait(false);

        response.EnsureSuccessStatusCode();
        
        TokensDto? newTokens = await response.Content.ReadFromJsonAsync<TokensDto>(cancellationToken)
            .ConfigureAwait(false) ?? throw new InvalidOperationException("Failed to refresh access token.");

        _tokenRepository.SaveTokens(newTokens);
        return newTokens.AccessToken;
    }

    private static bool IsUnauthorizedRequest(HttpRequestException exception, Uri? requestUri)
    {
        return exception.StatusCode == HttpStatusCode.Unauthorized && 
            requestUri != null && !requestUri.AbsolutePath.Contains("token");
    }
}

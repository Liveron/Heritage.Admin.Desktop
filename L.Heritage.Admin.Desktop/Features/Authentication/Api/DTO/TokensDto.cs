namespace L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;

public record class TokensDto(string AccessToken = "", string RefreshToken = "") { }

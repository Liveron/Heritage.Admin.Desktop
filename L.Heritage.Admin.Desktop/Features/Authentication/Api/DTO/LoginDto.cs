namespace L.Heritage.Admin.Desktop.Features.Authentication.Api.DTO;

public record class LoginDto
{
    public string UserName { get; init; } = string.Empty;
    public string Password { get; init; } = string.Empty;
}
 
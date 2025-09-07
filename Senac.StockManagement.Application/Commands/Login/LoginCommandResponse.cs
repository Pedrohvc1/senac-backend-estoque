namespace Senac.StockManagement.Application.Commands.Login;

public class LoginCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }

    public LoginCommandResponse()
    {
    }

    public LoginCommandResponse(bool success, string message, string token = "", DateTime? expiresAt = null)
    {
        Success = success;
        Message = message;
        Token = token;
        ExpiresAt = expiresAt ?? DateTime.Now.AddHours(1);
    }
}

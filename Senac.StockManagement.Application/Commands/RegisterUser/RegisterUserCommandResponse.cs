namespace Senac.StockManagement.Application.Commands.RegisterUser;

public class RegisterUserCommandResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public int? UserId { get; set; }

    public RegisterUserCommandResponse()
    {
    }

    public RegisterUserCommandResponse(bool success, string message, int? userId = null)
    {
        Success = success;
        Message = message;
        UserId = userId;
    }
}

using MediatR;

namespace Senac.StockManagement.Application.Commands.Login;

public class LoginCommandRequest : IRequest<LoginCommandResponse>
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

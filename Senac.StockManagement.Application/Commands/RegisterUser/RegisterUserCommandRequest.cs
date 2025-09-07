using MediatR;

namespace Senac.StockManagement.Application.Commands.RegisterUser;

public class RegisterUserCommandRequest : IRequest<RegisterUserCommandResponse>
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

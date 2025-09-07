using MediatR;
using Senac.StockManagement.Domain.Interfaces.Repositories;

namespace Senac.StockManagement.Application.Commands.Login;

public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, LoginCommandResponse>
{
    private readonly IUserRepository _userRepository;

    public LoginCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle the Login command to authenticate user and return JWT token.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<LoginCommandResponse> Handle(LoginCommandRequest command, CancellationToken cancellationToken)
    {
        try
        {
            // Buscar usuário no banco de dados pelo email
            var user = await _userRepository.GetByEmailAsync(command.Email);

            if (user == null)
            {
                return new LoginCommandResponse(false, "Email ou senha incorretos.");
            }

            // Verificar se o usuário está ativo
            if (!user.Active)
            {
                return new LoginCommandResponse(false, "Usuário inativo. Entre em contato com o administrador.");
            }

            // Por enquanto, verificação simples de senha (texto plano)
            // TODO: Implementar verificação de hash BCrypt
            if (user.PasswordHash != command.Password)
            {
                return new LoginCommandResponse(false, "Email ou senha incorretos.");
            }

            // Atualizar último login (opcional)
            // user.LastLoginAt = DateTime.Now;
            // await _userRepository.UpdateAsync(user);

            // Gerar token JWT
            var token = GenerateJwtToken(user.Email, user.Name);
            var expiresAt = DateTime.Now.AddHours(8);

            return new LoginCommandResponse(true, "Login realizado com sucesso.", token, expiresAt);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro no login para o usuário {command.Email}: {e.Message}");
            Console.WriteLine($"Stack trace: {e.StackTrace}");
            throw;
        }
    }

    private string GenerateJwtToken(string email, string nome)
    {
        // TODO: Implementar geração real de JWT token
        // Por enquanto, retornando um token fake para demonstração
        var userData = $"{email}:{nome}:{DateTime.Now:yyyyMMddHHmmss}";
        var fakeToken = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(userData));
        return $"Bearer.{fakeToken}";
    }
}
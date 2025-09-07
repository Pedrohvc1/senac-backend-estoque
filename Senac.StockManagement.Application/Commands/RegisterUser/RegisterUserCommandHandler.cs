using AutoMapper;
using MediatR;
using Senac.StockManagement.Domain.Entities;
using Senac.StockManagement.Domain.Interfaces.Repositories;

namespace Senac.StockManagement.Application.Commands.RegisterUser;

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommandRequest, RegisterUserCommandResponse>
{
    private readonly IUserRepository _userRepository;

    public RegisterUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    /// <summary>
    /// Handle the RegisterUser command to create a new user in the system.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<RegisterUserCommandResponse> Handle(RegisterUserCommandRequest command,
        CancellationToken cancellationToken)
    {
        try
        {
            // Verificar se o email já existe
            var emailExists = await _userRepository.EmailExistsAsync(command.Email);
            if (emailExists)
            {
                return new RegisterUserCommandResponse(false, "Este email já está cadastrado no sistema.");
            }

            // Criar novo usuário
            var user = new User
            {
                Name = command.Nome,
                Email = command.Email,
                PasswordHash = command.Password,
                Active = true,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

            return new RegisterUserCommandResponse(true, "Usuário cadastrado com sucesso.", user.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Erro no cadastro do usuário {command.Email}: {e.Message}");
            Console.WriteLine($"Stack trace: {e.StackTrace}");
            throw;
        }
    }
}
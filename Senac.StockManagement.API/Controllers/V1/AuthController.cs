using Microsoft.AspNetCore.Mvc;
using Senac.StockManagement.Application.Commands.Login;
using Senac.StockManagement.Application.Commands.RegisterUser;

namespace Senac.StockManagement.API.Controllers.V1;

public class AuthController : BaseApiController
{
    /// <summary>
    /// Authenticates a user and returns a JWT token.
    /// </summary>
    /// <param name="command">Command containing the user credentials (email and password).</param>
    /// <returns>
    /// Returns HTTP 200 (OK) status with authentication result and JWT token if successful,
    /// or HTTP 401 (Unauthorized) if credentials are invalid.
    /// </returns>
    [HttpPost("login")]
    public async Task<IActionResult> LoginAsync([FromBody] LoginCommandRequest command)
    {
        var result = await Mediator.Send(command);
        
        if (result.Success)
        {
            return Ok(result);
        }
        
        return Unauthorized(result);
    }

    /// <summary>
    /// Registers a new user in the system.
    /// </summary>
    /// <param name="command">Command containing the user registration data (nome, email and password).</param>
    /// <returns>
    /// Returns HTTP 201 (Created) status with registration result if successful,
    /// or HTTP 400 (Bad Request) if data is invalid or email already exists.
    /// </returns>
    [HttpPost("register")]
    public async Task<IActionResult> RegisterAsync([FromBody] RegisterUserCommandRequest command)
    {
        var result = await Mediator.Send(command);
        
        if (result.Success)
        {
            return Created(string.Empty, result);
        }
        
        return BadRequest(result);
    }
}

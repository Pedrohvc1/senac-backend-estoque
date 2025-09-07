using Microsoft.AspNetCore.Mvc;
using Senac.StockManagement.Application.Commands.Login;

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
}

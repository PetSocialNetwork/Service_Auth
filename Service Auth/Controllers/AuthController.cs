using Microsoft.AspNetCore.Mvc;
using Service_Auth.Exceptions;
using Service_Auth.Models;
using Service_Auth.Services;
using Service_Auth.Services.Interfaces;

namespace Service_Auth.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly ITokenService _tokenService;

        public AuthController(AuthService authService, ITokenService tokenService)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(InvalidOperationException))]
        //[ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(EmailAlreadyExistsException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("register")]
        public async Task<ActionResult<RegisterResponse>> Register
            ([FromBody]RegisterRequest request, CancellationToken cancellationToken)
        {
            var response =
                await _authService.Register(request.Email, request.Password, cancellationToken);
            return Ok(new RegisterResponse(response.Id, response.Email.ToString()));
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(InvalidPasswordException))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(AccountNotFoundException))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginByPassword(LoginRequest request, CancellationToken cancellationToken)
        {
            var account = await _authService.LoginByPassword(request.Email, request.Password, cancellationToken);
            var token = _tokenService.GenerateToken(account);
            return Ok(new LoginResponse(account.Id, account.Email.ToString(), token));
        }
    }
}

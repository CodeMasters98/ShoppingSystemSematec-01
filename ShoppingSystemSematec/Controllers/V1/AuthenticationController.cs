using Microsoft.AspNetCore.Mvc;
using ShoppingSystemSematec.Application.Contracts;
using ShoppingSystemSematec.Application.Dtos;
using ShoppingSystemSematec.Controllers;
using System.Net.Mime;

namespace ShoppingSystemSematec.Api.Controllers.V1;

public class AuthenticationController : BaseController
{
    private readonly IAuthenticationService _authenticationService;
    public AuthenticationController(IAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Route("Login")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
    {
        var result = await _authenticationService.Login(dto);
        return Ok(result);
    }

    [Route("Register")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
    {
        var result = await _authenticationService.Register(dto);
        return Ok(result);
    }
}

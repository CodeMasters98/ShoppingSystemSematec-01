using Microsoft.AspNetCore.Mvc;
using ShoppingSystemSematec.Application.Dtos;
using ShoppingSystemSematec.Controllers;
using ShoppingSystemSematec.Domain.Entities;
using System.Net.Mime;

namespace ShoppingSystemSematec.Api.Controllers.V1;

public class AuthenticationController : BaseController
{
    [Route("Login")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Login([FromBody] LoginDto dto, CancellationToken ct)
    {
        return Created();
    }

    [Route("Register")]
    [HttpPost]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RegisterDto dto, CancellationToken ct)
    {
        return Created();
    }
}

using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingSystemSematec.Controllers;

[Route("api/v{version:apiVersion}/[controller]/[action]")]
[ApiController]
[ApiVersion("1.0")]
public class BaseController : ControllerBase
{
    //Shared Code
    //Logger
    //CQRS Pattern, MediatR

}

using ShoppingSystemSematec.Application.Dtos;

namespace ShoppingSystemSematec.Application.Contracts;

public interface IAuthenticationService
{
    Task<AuthenticationResponseDto> Login(LoginDto dto);
    Task<AuthenticationResponseDto> Register(RegisterDto dto);
}

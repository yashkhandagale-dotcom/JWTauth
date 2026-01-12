using UserCRUDandJWT.DTOs;
using UserCRUDandJWT.Models;

namespace UserCRUDandJWT.Services.Interfaces
{
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);

        // 🔹 Login returns tokens now
        Task<AuthResponseDto> LoginAsync(LoginDto dto);

        // 🔹 Refresh access token
        Task<AuthResponseDto> RefreshTokenAsync(string refreshToken);
    }
}

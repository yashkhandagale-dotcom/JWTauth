using UserCRUDandJWT.Models;

namespace UserCRUDandJWT.Services.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(User user);
}

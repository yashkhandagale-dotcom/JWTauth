using UserCRUDandJWT.DTOs;
using UserCRUDandJWT.Models;

namespace UserCRUDandJWT.Services.Interfaces;
public interface IUserService
{
    Task<List<User>> GetAllAsync();
    Task<User?> GetByIdAsync(int id);
    Task DeleteAsync(int id);

    Task UpdateAsync(int id, UpdateUserDto dto);

}


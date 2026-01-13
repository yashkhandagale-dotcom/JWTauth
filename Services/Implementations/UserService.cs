using Microsoft.EntityFrameworkCore;
using UserCRUDandJWT.Data;
using UserCRUDandJWT.DTOs;
using UserCRUDandJWT.Models;
using UserCRUDandJWT.Services.Interfaces;

namespace UserCRUDandJWT.Services.Implementations;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetAllAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task DeleteAsync(int id)
    {
        var user = await GetByIdAsync(id);
        if (user == null) return;

        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }


    public async Task UpdateAsync(int id, UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(id);
        if (user == null)
            throw new Exception("User not found");

        // 🔐 Validate role
        var allowedRoles = new[]
        {
                UserRoles.Admin,
                UserRoles.User,
                UserRoles.Operator,
                UserRoles.Engineer
            };

        if (!allowedRoles.Contains(dto.Role))
            throw new Exception("Invalid role");

        user.Username = dto.Username;
        user.Email = dto.Email;
        user.Role = dto.Role;

        await _context.SaveChangesAsync();
    }
}


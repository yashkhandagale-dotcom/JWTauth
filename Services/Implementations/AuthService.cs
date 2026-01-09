using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using UserCRUDandJWT.Data;
using UserCRUDandJWT.DTOs;
using UserCRUDandJWT.Models;
using UserCRUDandJWT.Services.Interfaces;

namespace UserCRUDandJWT.Services.Implementations { 

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;

    public AuthService(AppDbContext context)
    {
        _context = context;
    }

    public async Task RegisterAsync(RegisterDto dto)
    {
        if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            throw new Exception("User already exists");

            if (await _context.Users.AnyAsync(u => u.Username == dto.Username))
                throw new Exception("choose a diff username");

        var user = new User
        {
            Username = dto.Username,
            Email = dto.Email,
            PasswordHash = HashPassword(dto.Password)
        };

        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        }

        public async Task<bool> LoginAsync(LoginDto dto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null) return false;

            return user.PasswordHash == HashPassword(dto.Password);
        }

        public async Task<User?> ValidateUserAsync(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) return null;

            return user.PasswordHash == HashPassword(dto.Password) ? user : null;
        }

        private static string HashPassword(string password)
    {
        using var sha = SHA256.Create();
        return Convert.ToBase64String(
            sha.ComputeHash(Encoding.UTF8.GetBytes(password))
        );
    }
}
    }
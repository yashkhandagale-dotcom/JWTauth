using System;
using UserCRUDandJWT.DTOs;
using UserCRUDandJWT.Models;

namespace UserCRUDandJWT.Services.Interfaces;
    public interface IAuthService
    {
        Task RegisterAsync(RegisterDto dto);
    Task<bool> LoginAsync(LoginDto dto);
    Task<User?> ValidateUserAsync(LoginDto dto);
   

}


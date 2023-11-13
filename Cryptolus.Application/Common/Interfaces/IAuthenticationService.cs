using Cryptolus.Application.DTOs;
using Cryptolus.Domain.Entities.User;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Application.Common.Interfaces
{
    public interface IAuthenticationService
    {
        string Authenticate(LoginDto login);
        Task<Guid> Register(UserDto user);
        Task<bool> ForgotPassword(string email);
        Task<bool> ResetPassword(string email,string token,string newPassword);
        Task<bool> ChangePassword(string email,string currentPassword,string newPassword);
        Task<bool> SignOut(IHttpContextAccessor httpContextAccessor);
        Task<bool> IsAuthenticated(string email);
        Task<bool> IsEmailRegistered(string email);
        string GenerateToken(User user);
        bool ValidateToken(string token);
    }
}

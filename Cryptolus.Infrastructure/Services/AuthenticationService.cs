using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Application.DTOs;
using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Entities.User;
using Cryptolus.Infrastructure.Options;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using IAuthenticationService = Cryptolus.Application.Common.Interfaces.IAuthenticationService;

namespace Cryptolus.Infrastructure.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;
        private readonly IUnitOfWork _unitOfWork;


        public AuthenticationService(IConfiguration configuration,IUnitOfWork unitOfWork,IUserRepository userRepository)
        {
            _configuration = configuration;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }


        #region TODO
        // TODO

        public Task<bool> ForgotPassword(string email)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ResetPassword(string email,string token,string newPassword)
        {
            throw new NotImplementedException();
        }

        // TODO
        #endregion


        public bool ValidateToken(string token)
        {
            var parameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = AuthOptions.ISSUER,
                ValidAudience = AuthOptions.AUDIENCE,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey()
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken validatedToken;
            try
            {
                tokenHandler.ValidateToken(token,parameters,out validatedToken);
            }
            catch(Exception)
            {
                return false;
            }
           
            return true;
        }


        public string Authenticate(LoginDto login)
        {
            var user = _userRepository.GetUserByEmail(login.Email).Result;
            if(user == null)
                throw new Exception("user not found");

            if(!VerifyPassword(login.Password,user.Password))
                throw new Exception("password do not match");

            return GenerateToken(user);
        }

        public async Task<bool> ChangePassword(string email,string currentPassword,string newPassword)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if(user == null)
                throw new Exception("user do not find out");

            var checkCurrentPassword = VerifyPassword(currentPassword,user.Password);

            if(!checkCurrentPassword)
                throw new Exception("invalid password");

            user.Password = HashPassword(newPassword);

            if(_userRepository.UpdateAsync(user).IsFaulted)
                return false;

            return true;
        }

        public async Task<bool> SignOut(IHttpContextAccessor httpContextAccessor)
        {
            // delete token and InAuth = false;
            return true;
        }

        public string GenerateToken(User user)
        {
            //if(user.IsAuthenticated)
            //    throw new Exception("you are authentificate yet");

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.UserName.ToString()),
                    new Claim(ClaimTypes.Actor,user.Id.ToString()),
                    new Claim(ClaimTypes.Email, user.Email.ToString()),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.ToString())
                }), 
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(),SecurityAlgorithms.HmacSha256)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.IsAuthenticated = true;
            return tokenHandler.WriteToken(token);
        }

        public async Task<bool> IsAuthenticated(string email)
        {
            return _userRepository.GetUserByEmail(email).Result.IsAuthenticated;
        }

        public async Task<bool> IsEmailRegistered(string email)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if(user == null)
                return false;

            return true;
        }

        public async Task<Guid> Register(UserDto user)
        {
            var exeUser = await _userRepository.GetUserByEmail(user.Email);
            if(exeUser != null)
                return Guid.Empty;
            if(user.Password != user.ConfirmPassword)
                throw new Exception("passwords do not match");

            var newUser = new User
            {
                Id = Guid.NewGuid(),
                UserName = user.UserName,
                Email = user.Email,
                Password = HashPassword(user.Password),
                IsAuthenticated = true,
                Role = Role.Member
            };
            await _userRepository.AddAsync(newUser);
            await _unitOfWork.Save(default);  
            return newUser.Id;
        }

        private bool VerifyPassword(string password,string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password,hashedPassword);
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}

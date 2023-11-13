using Cryptolus.Application.Common.Interfaces;
using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Domain.Entities.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace Cryptolus.Presentation.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAuthenticationService _authenticationService;

        public AdminController(IUnitOfWork unitOfWork, IAuthenticationService authenticationService )
        {
            _authenticationService = authenticationService;
            _unitOfWork = unitOfWork;
        }


        [HttpGet("/getAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var allUsers = await _unitOfWork.Repository<User>().GetAllAsync();
            return Ok(allUsers);
        }


        [HttpPost("/checkToken")]
        public async Task<IActionResult> Check([FromBody]string token)
        {
            var result =  _authenticationService.ValidateToken(token);
            return Ok(result);
        }

    }
}

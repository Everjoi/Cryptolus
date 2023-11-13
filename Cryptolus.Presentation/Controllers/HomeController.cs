using Cryptolus.Application.Common.Interfaces;
using Cryptolus.Application.Common.Interfaces.Repositories;
using Cryptolus.Application.DTOs;
using Cryptolus.Domain.Entities.CoinInfo;
using Cryptolus.Presentation.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Cryptolus.Presentation.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserRepository _userRepository;
        private readonly ICoinInfoService _coinInfoService;

        public HomeController(ICoinInfoService coinInfoService, IAuthenticationService authenticationService, IUserRepository userRepository)
        {
            _authenticationService = authenticationService;
            _userRepository = userRepository;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }



        [HttpPost("/register")]
        public async Task<IActionResult> UserRegister([FromBody] UserDto userDto)
        {
            var userId = await _authenticationService.Register(userDto);
            return Ok(userId);
        }


        [HttpPost("/login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto loginDto)
        {
            var token = _authenticationService.Authenticate(loginDto);
            return Ok(token);
        }


        [HttpGet]
        public Task<IActionResult> Payment()
        {
            return null; // Payment service 
        }


        
        public async Task<List<CoinData>> GetCoinInfo()
        {
            var coins = await _coinInfoService.GetSeveralCoins(count:15);
            return coins;
        }


        public IActionResult About()
        {
            return View();
        }




    }
}
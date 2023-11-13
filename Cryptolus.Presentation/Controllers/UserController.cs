using Cryptolus.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace Cryptolus.Presentation.Controllers
{

    // CRUD 

    [Authorize]
    public class UserController : Controller
    {
        private readonly IAuthenticationService _authenticationService;

        public UserController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpGet("/getownData")]
        public async Task<IActionResult> ViewOwnData()
        {
            return Ok("User secrets");
        }

        [HttpGet("/signOut")]
        public async Task<IActionResult> SignOut()
        {
             
            var t = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Email).FirstOrDefault();

            //var result = await  _authenticationService.SignOut(new HttpContextAccessor() { HttpContext = this.HttpContext});

            var result = t.ToString();

            return Ok(result);
        }

    }
}

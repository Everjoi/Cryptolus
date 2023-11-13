using Cryptolus.Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Cryptolus.Presentation.Controllers
{
    public class CoinInfoController : Controller
    {
        private readonly ICoinInfoService _coinInfoService;

        public CoinInfoController(ICoinInfoService coinInfoService )
        {
            _coinInfoService = coinInfoService;
        }


        [HttpGet("/coins/all")]
        public async Task<IActionResult> GetAllCoins(string curr = "usd")
        {
            var res = await  _coinInfoService.GetCoinData(curr);
            return Ok(res);
        }

        [HttpGet("/several/coins")]
        public async Task<IActionResult> GetCoins(string curr = "usd",int count = 10)
        {
            var res = await _coinInfoService.GetSeveralCoins(curr,count);
            return Ok(res);
        }

    }
}

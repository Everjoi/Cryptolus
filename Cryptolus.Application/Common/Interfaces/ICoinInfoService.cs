using Cryptolus.Application.DTOs;
using Cryptolus.Domain.Entities.CoinInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Application.Common.Interfaces
{
    public interface ICoinInfoService
    {
        Task<List<CoinData>> GetCoinData(string currency="usd");
        Task<List<CoinData>> GetSeveralCoins(string currency = "usd", int count = 10);
    }
}

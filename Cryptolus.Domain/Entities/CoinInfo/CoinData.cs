using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Domain.Entities.CoinInfo
{
    public class CoinData
    {
        public string Symbol { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        [JsonProperty("current_price")]
        public decimal CurrentPrice { get; set; }
        [JsonProperty("high_24h")]
        public decimal High24h { get; set; }
        [JsonProperty("low_24h")]
        public decimal Low24h { get; set; }
        [JsonProperty("price_change_24h")]
        public decimal PriceChange { get; set; }
        [JsonProperty("price_change_percentage_24h")]
        public double PriceChangePercentage { get; set; }
        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }
    }
}

using Cryptolus.Domain.Common.Interfaces;

namespace Cryptolus.Domain.Entities.Post
{
    public class PostContent : IEntity
    {
        public Guid Id { get; set; }
        public string CoinSymbol { get; set; } = string.Empty;
        public string Coin { get; set; } = string.Empty;
        public string Body { get; set; } = string.Empty;
        public string Picture { get; set; } = string.Empty;
    }
}
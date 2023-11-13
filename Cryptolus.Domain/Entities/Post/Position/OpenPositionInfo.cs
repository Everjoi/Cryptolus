using Cryptolus.Domain.Common.Interfaces;

namespace Cryptolus.Domain.Entities.Post.Position
{
    public class OpenPositionInfo : IEntity
    {
        public Guid Id { get; set; }
        public double EnterPrice { get; set; }
        public double TakeProfit { get; set; }
        public double StopLoss { get; set; }
        public double TpSl { get; set; }
    }
}
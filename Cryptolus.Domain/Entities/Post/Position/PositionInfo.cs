using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Common.Interfaces;

namespace Cryptolus.Domain.Entities.Post.Position
{
    public class PositionInfo : IEntity
    {
        public Guid Id { get; set; }
        public PositionStatus Status { get; set; }
        public PositionDirection Direction { get; set; }
        public PositionResult PositionResult { get; set; }
        public OpenPositionInfo Info { get; set; } = new();
    }


}
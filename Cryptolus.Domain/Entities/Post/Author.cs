using Cryptolus.Domain.Common.Interfaces;

namespace Cryptolus.Domain.Entities.Post
{
    public class Author:IEntity
    {
        public Guid Id { get ; set ; }
        public string UserName { get; set; } = string.Empty;
        public string Photo { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
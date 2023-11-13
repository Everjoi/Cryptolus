using Cryptolus.Domain.Common.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cryptolus.Domain.Entities.Post
{
    public class Themes : IEntity
    {
        public Guid Id { get; set; }
        public string Body { get; set; } = string.Empty;
        public ICollection<PostThemes> PostThemes { get; set; } = new List<PostThemes>();
    }

}
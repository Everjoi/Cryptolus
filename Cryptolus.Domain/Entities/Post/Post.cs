using Cryptolus.Domain.Common.Constants;
using Cryptolus.Domain.Common.Interfaces;
using Cryptolus.Domain.Entities.Post.Position;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Domain.Entities.Post
{
    public class Post : IEntity
    { 
        public Guid Id { get; set; }
        public PostContent Content { get; set; } = new PostContent();
        public DateTime CreateDate { get; set; }
        public Author Author { get; set; } = new Author();
        public bool IsChanged { get; set; } = false;
        public int ViewsCount { get; set; }
        public Subscription Type { get; set; }
        public PositionInfo Position { get; set; } = new PositionInfo();
        public ICollection<PostThemes> PostThemes { get; set; } = new List<PostThemes>();
    }

}

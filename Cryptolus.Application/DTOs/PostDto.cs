using Cryptolus.Application.Mappings;
using Cryptolus.Domain.Entities.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Application.DTOs
{
    public class PostDto : IMapFrom<Post>
    { 
        public PostContent Content { get; set; } = new();
        public List<Themes> KeyThemes { get; set; } = new();
        public string Photo { get; set; } = string.Empty;
    }
}

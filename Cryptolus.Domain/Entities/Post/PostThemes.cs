using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptolus.Domain.Entities.Post
{
    public class PostThemes
    {
        
        public Guid PostId { get; set; }
        public Post Post { get; set; } = new();

       
        public Guid ThemeId { get; set; }
        public Themes Theme { get; set; } = new();
    }

}

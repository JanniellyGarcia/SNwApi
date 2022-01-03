using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Post : BaseEntity
    {
        public string Description { get; set; }
        public List<Like> LikesDoPost { get; set; }
        public List<Deslike> DeslikesDoPost { get; set; }
        public List<Comment> CommentsDoPost { get; set; }
        public int userIdPost { get; set; }
        public User userId { get; set; }

        //about image:
        public string Image { get; set; }
        public string Type { get; set; }
        public string Path { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Like : BaseEntity
    {
        public int PostId { get; set; }
        public Post Postagem { get; set; }
        public int UserId { get; set; }
        public User IdUsuário { get; set; }
    }
}

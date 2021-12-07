using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IPostRepository : IBaseRepository<Post>
    {
        IEnumerable<Post> GetPost();
        Post GetById(int id);

    }
}

using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(SqlContext context) : base(context)
        {

        }
        public Post GetById(int id)
        {
            var obj = CurrentSet
                    .Where(x => x.Id == id)
                    .FirstOrDefault();
            return obj;
        }

        public IEnumerable<Post> GetPost()
        {
            throw new NotImplementedException();
        }
    }
}

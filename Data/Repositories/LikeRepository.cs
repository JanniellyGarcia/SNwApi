using Data.Context;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LikeRepository : BaseRepository<Like>, ILikeRepository
    {
        public LikeRepository(SqlContext context) : base(context)
        {

        }
        public Like GetById(int id)
        {
            var obj = CurrentSet
                .Include(x => x.IdUser)
                .Include(x => x.IdPost)
                .Where(x => x.Id == id) 
                .FirstOrDefault(); 
            return obj;
        }

        public IEnumerable<Like> GetLikes()
        {
            var obj = CurrentSet
                 .ToList();
            return obj;
        }
    }
}

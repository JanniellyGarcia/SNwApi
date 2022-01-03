using Data.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CommentRepository  : BaseRepository<Comment> , ICommentRepository
    {
        public CommentRepository(SqlContext context) : base(context)
        {

        }
        public Comment GetById(int Id)
        {
            var obj = CurrentSet
                .Include(x => x.UserId)
                .Include(x => x.PostId)
                .Where(x => x.Id == Id)
                .FirstOrDefault();
            return obj;
        }

        public IEnumerable<Comment> GetComment()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }
    }
}

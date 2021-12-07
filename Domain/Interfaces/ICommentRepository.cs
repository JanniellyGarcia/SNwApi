using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ICommentRepository
    {
        IEnumerable<Comment> GetComment();
        Comment GetById(int Id);
    }
}

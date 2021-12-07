using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface ILikeRepository
    {
        IEnumerable<Like> GetLikes();
        Like GetById(int id);
    }
}

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
    public class DeslikeRepository : BaseRepository<Deslike> , IDeslikeRepository
    {
        
        public DeslikeRepository(SqlContext context) : base(context)
        {

        }

        public Deslike GetById(int id)
        {
            var obj = CurrentSet
                .Include(x => x.IdUser)
                .Include(x => x.IdPost)
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return obj;
        }

        public IEnumerable<Deslike> GetDeslike()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }
    }
}

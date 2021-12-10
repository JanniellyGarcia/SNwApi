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
    public class NewsRepository : BaseRepository<News> , INewRepository
    {
        public NewsRepository(SqlContext context) : base(context)
        {

        }

        public News GetById(int id)
        {
            var obj = CurrentSet
                .Where(x => x.Id == id)
                .FirstOrDefault();
            return obj;
        }

        public IEnumerable<News> GetNews()
        {
            var obj = CurrentSet
                 .ToList();
            return obj;
        }
    }
}

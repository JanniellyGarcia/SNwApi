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
    public class ChatRepository : BaseRepository<Chat> , IChatRepository
    {
        public ChatRepository(SqlContext context) :  base (context)
        {

        }

        public Chat GetById(int Id)
        {
            var obj = CurrentSet
                .Include(x => x.EmissorId)
                .Include(x => x.ReceptorId)
                .Where(x => x.Id == Id)
                .FirstOrDefault();
            return obj;
        }

        public IEnumerable<Chat> GetChat()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }
    }
}

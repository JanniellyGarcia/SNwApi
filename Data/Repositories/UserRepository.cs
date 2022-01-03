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
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(SqlContext context) : base(context)
        {

        }

        public User GetAllAuthentication(string emailAut, string senhaAut)
        {
            var obj = CurrentSet
                         .Where(x => x.Email == emailAut && x.Senha == senhaAut)
                         .FirstOrDefault();
            return obj;
        }

        public User GetById(int id)
        {
            var obj = CurrentSet
                .Where(x => x.Id == id) // Pega do banco de dados e no campo de id coloca o id recebido
                .FirstOrDefault(); // Seleciona somente 1, o primeiro.
            return obj;
            
        }
        

        public IEnumerable<User> GetUser()
        {
            var obj = CurrentSet
                .ToList();
            return obj;
        }
    }
}

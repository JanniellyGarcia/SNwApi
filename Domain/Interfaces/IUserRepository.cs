using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetById(int id);
        User GetAllAuthentication(string emailAut, string senhaAut);
        
    }
}

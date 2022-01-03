
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService 
    {
        IEnumerable<UserViewModel> GetUser();
        User GetUserForLogin(string email, string senha);

    }
}

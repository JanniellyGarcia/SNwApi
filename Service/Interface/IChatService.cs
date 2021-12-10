using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IChatService
    {
        IEnumerable<ChatViewModel> GetChat(); 
    }
}

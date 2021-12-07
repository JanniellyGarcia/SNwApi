using Microsoft.AspNetCore.Http;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> GetPost();
        // PostViewModel GetById(int id);
       string uploadImagem(IFormFile Arquivo, int id);
    }
}

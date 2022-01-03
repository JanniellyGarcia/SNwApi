using AutoMapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Http;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class NewsService : INewsService
    {
        private INewRepository _newRepository;
        private readonly IMapper _mapper;
        public NewsService(INewRepository newRepository, IMapper mapper)
        {
            _newRepository = newRepository;
            _mapper = mapper;
        }

        public IEnumerable<NewsViewModel> GetNews()
        {
            var news = _newRepository.GetNews();
            return _mapper.Map<IEnumerable<NewsViewModel>>(news);
        }

        public string uploadImagem(IFormFile Arquivo, int id)
        {
            if (Arquivo.Length > 0)
            {

                try
                {
                    if (!Directory.Exists("C:\\images\\"))
                    {
                        Directory.CreateDirectory("C:\\images\\");
                    }

                    using (FileStream fileStream = System.IO.File.Create("C:\\images\\" + Arquivo.FileName))
                    {
                        Arquivo.CopyToAsync(fileStream);
                        fileStream.Flush();
                        return "C:\\images\\" + Arquivo.FileName;
                    }
                }
                catch (Exception e)
                {
                    return e.ToString();
                }

            }
            else
            {
                return "Arquivo com falha.....";
            }
        }
    }
}

using AutoMapper;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Service.Interface;
using Service.Validation;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        private readonly IMapper _mapper;

        public PostService(IPostRepository postRepository, IMapper mapper)
        {
            _postRepository = postRepository;
            _mapper = mapper;
        }
        public IEnumerable<PostViewModel> GetPost()
        {
            var post = _postRepository.GetPost();
            return _mapper.Map<IEnumerable<PostViewModel>>(post); //mapeado objetos de model para viewmodel
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


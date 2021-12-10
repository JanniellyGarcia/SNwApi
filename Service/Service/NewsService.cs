using AutoMapper;
using Domain.Interfaces;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
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
    }
}

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
    public class LikeService : ILikeService
    {
        private ILikeRepository _likeRepository;
        private readonly IMapper _mapper;
        public LikeService(ILikeRepository likeRepository, IMapper mapper)
        {
            _likeRepository = likeRepository;
            _mapper = mapper;

        }

        public IEnumerable<LikeViewModel> GetLike()
        {
            var like = _likeRepository.GetLikes();
            return _mapper.Map<IEnumerable<LikeViewModel>>(like); //mapeado objetos de model para viewmodel
        }
    }
}

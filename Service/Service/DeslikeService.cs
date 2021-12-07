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
    public class DeslikeService : IDeslikeService
    {
        private IDeslikeRepository _deslikeRepository;
        private readonly IMapper _mapper;
        public DeslikeService(IDeslikeRepository deslikeRepository, IMapper mapper)
        {
            _deslikeRepository = deslikeRepository;
            _mapper = mapper;

        }

        public IEnumerable<DeslikeViewModel> GetDeslike()
        {
            var deslike = _deslikeRepository.GetDeslike();
            return _mapper.Map<IEnumerable<DeslikeViewModel>>(deslike); //mapeado objetos de model para viewmodel
        }
    }
}

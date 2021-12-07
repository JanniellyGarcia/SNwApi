using AutoMapper;
using Data.Repositories;
using Domain.Models;
using Service.Interface;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Service
{
    public class CommnetService : ICommentService
    {
        private ICommentRepository _commentRepository;
        private readonly IMapper _mapper;
        public CommnetService(ICommentRepository commentRepository, IMapper mapper)
        {
            _commentRepository = commentRepository;
            _mapper = mapper;

        }

        public IEnumerable<CommentViewModel> GetComment()
        {
            var comment = _commentRepository.GetComment();
            return _mapper.Map<IEnumerable<CommentViewModel>>(comment); //mapeado objetos de model para viewmodel
        }
    }
}

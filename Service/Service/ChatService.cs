using AutoMapper;
using Domain.Interfaces;
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
    public class ChatService : IChatService
    {
        private IChatRepository _chatRepository;
        private readonly IMapper _mapper;
        public ChatService(IChatRepository chatRepository, IMapper mapper)
        {
            _chatRepository = chatRepository;
            _mapper = mapper;
        }

        IEnumerable<ChatViewModel> IChatService.GetChat()
        {
            var chat = _chatRepository.GetChat();
            return _mapper.Map<IEnumerable<ChatViewModel>>(chat); //mapeado objetos de model para viewmodel
        }
    }
}

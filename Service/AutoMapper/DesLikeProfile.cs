using AutoMapper;
using Domain.Models;
using Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.AutoMapper
{
    public class DesLikeProfile : Profile
    {
        public DesLikeProfile()
        {
            CreateMap<DeslikeViewModel, Deslike>().ReverseMap();
        }
    }
}

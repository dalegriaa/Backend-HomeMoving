
using Application.Dto;
using AutoMapper;
using Domain.Entity;

namespace Transversal.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DataFileUser, DataFileUserDto>().ReverseMap();
        }
    }
}

using AutoMapper;
using HomeworkApi.Data;
using HomeworkApi.Dto;

namespace HomeworkApi.Service
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Account, AccountDto>().ReverseMap();
            CreateMap<Person, PersonDto>().ReverseMap();
            
        }

    }
}

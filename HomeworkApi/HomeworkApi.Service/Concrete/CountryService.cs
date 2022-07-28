using AutoMapper;
using HomeworkApi.Data;
using HomeworkApi.Dto;

namespace HomeworkApi.Service
{
    public class CountryService : BaseService<CountryDto, Country>, ICountryService
    {
        public CountryService(ICountryRepository countryRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(countryRepository, mapper, unitOfWork)
        {
        }
    }
}

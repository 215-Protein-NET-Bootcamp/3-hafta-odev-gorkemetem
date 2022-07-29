using HomeworkApi.Data;
using HomeworkApi.Dto;

namespace HomeworkApi.Service
{
    public interface IPersonService : IBaseService<PersonDto, Person>
    {
    }
}

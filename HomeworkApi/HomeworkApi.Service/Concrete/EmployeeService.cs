using AutoMapper;
using HomeworkApi.Data;
using HomeworkApi.Dto;

namespace HomeworkApi.Service
{
    public class EmployeeService : BaseService<EmployeeDto, Employee>, IEmployeeService
    {
        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(employeeRepository, mapper, unitOfWork)
        {
            
        }


    }
}

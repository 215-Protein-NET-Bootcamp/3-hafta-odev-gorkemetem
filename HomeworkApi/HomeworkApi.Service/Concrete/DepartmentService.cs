using AutoMapper;
using HomeworkApi.Data;
using HomeworkApi.Dto;

namespace HomeworkApi.Service
{
    public class DepartmentService : BaseService<DepartmentDto, Department>, IDepartmentService
    {
        public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper, IUnitOfWork unitOfWork) : base(departmentRepository, mapper, unitOfWork)
        {
            
        }

      
    }
}

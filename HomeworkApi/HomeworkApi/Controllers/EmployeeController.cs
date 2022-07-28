using AutoMapper;
using HomeworkApi.Data;
using HomeworkApi.Dto;
using HomeworkApi.Service;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System.Threading.Tasks;

namespace HomeworkApi
{
    [Route("api/v1/homework/[controller]")]
    [ApiController]
    public class EmployeeController : BaseController<EmployeeDto, Employee>
    {

        public EmployeeController(IEmployeeService EmployeeService, IMapper mapper) : base(EmployeeService, mapper)
        {
            
        }

        [HttpGet("{id:int}")]
        public new async Task<IActionResult> GetByIdAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: get a Employee with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] EmployeeDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a Employee.");

            return await base.CreateAsync(resource);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] EmployeeDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a Department with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a Department with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}

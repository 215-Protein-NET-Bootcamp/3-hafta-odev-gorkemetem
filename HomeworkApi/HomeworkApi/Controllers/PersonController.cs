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
    public class PersonController : BaseController<PersonDto, Person>
    {
        private readonly IPersonService personService;

        public PersonController(IPersonService personService, IMapper mapper) : base(personService, mapper)
        {
            this.personService = personService;
        }

        [HttpGet("{id:int}")]
        public new async Task<IActionResult> GetByIdAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: get a person with Id is {id}.");

            return await base.GetByIdAsync(id);
        }

        [HttpPost]
        public new async Task<IActionResult> CreateAsync([FromBody] PersonDto resource)
        {
            Log.Information($"{User.Identity?.Name}: create a person.");

            var insertResult = await personService.InsertAsync(resource);

            if (!insertResult.Success)
                return BadRequest(insertResult);

            return StatusCode(201, insertResult);
        }

        [HttpPut("{id:int}")]
        public new async Task<IActionResult> UpdateAsync(int id, [FromBody] PersonDto resource)
        {
            Log.Information($"{User.Identity?.Name}: update a person with Id is {id}.");

            return await base.UpdateAsync(id, resource);
        }


        [HttpDelete("{id:int}")]
        public new async Task<IActionResult> DeleteAsync(int id)
        {
            Log.Information($"{User.Identity?.Name}: delete a person with Id is {id}.");

            return await base.DeleteAsync(id);
        }

    }
}

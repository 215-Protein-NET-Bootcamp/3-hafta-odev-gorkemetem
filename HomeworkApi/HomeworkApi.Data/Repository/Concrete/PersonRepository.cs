using Homework.Data;
using HomeworkApi.Base;
using HomeworkApi.Dto;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkApi.Data
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(AppDbContext Context) : base(Context)
        {
        }

        
        private IQueryable<Person> ConditionFilter(PersonDto filterResource)
        {
            var queryable = Context.person.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filterResource.StaffId))
            {
                queryable.Where(x => x.StaffId == filterResource.StaffId);
            }

            if (filterResource != null)
            {

                if (!string.IsNullOrEmpty(filterResource.FirstName))
                {
                    string fullName = filterResource.FirstName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.FirstName.Contains(fullName));
                }

                if (!string.IsNullOrEmpty(filterResource.LastName))
                {
                    string fullName = filterResource.LastName.RemoveSpaceCharacter().ToLower();
                    queryable = queryable.Where(x => x.LastName.Contains(fullName));
                }
            }

            return queryable;
        }

        public override async Task<Person> GetByIdAsync(int id)
        {
            return await Context.person.AsSplitQuery().SingleOrDefaultAsync(x => x.AccountId == id);
        }

        public async Task<int> TotalRecordAsync()
        {
            return await Context.person.CountAsync();
        }
    }
}

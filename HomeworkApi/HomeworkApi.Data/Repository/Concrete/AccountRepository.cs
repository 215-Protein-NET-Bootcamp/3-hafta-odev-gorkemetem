using HomeworkApi.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace HomeworkApi.Data
{
    public class AccountRepository : BaseRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext context) : base(context) { }



        public async Task<Account> GetByIdAsync(int id, bool hasToken)
        {
            var queryable = Context.account.Where(x => x.Id.Equals(id));
            return await queryable.SingleOrDefaultAsync();
        }

        public async Task<int> TotalRecordAsync() => await Context.account.CountAsync();

        public async Task<Account> ValidateCredentialsAsync(TokenRequest loginResource)
        {
            var accountStored = await Context.account
                .Where(x => x.UserName == loginResource.UserName.ToLower())
                .SingleOrDefaultAsync();

            if (accountStored is null)
                return null;
            else
            {
                // Validate credential
                bool isValid = accountStored.Password.CheckingPassword(loginResource.Password);
                if (isValid)
                    return accountStored;
                else
                    return null;
            }
        }


    }
}

using HomeworkApi.Base;
using System.Threading.Tasks;

namespace HomeworkApi.Data
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        Task<int> TotalRecordAsync();
        Task<Account> ValidateCredentialsAsync(TokenRequest loginResource);
        Task<Account> GetByIdAsync(int id, bool hasToken);
    }
}

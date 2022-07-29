using HomeworkApi.Base;
using HomeworkApi.Data;
using HomeworkApi.Dto;
using System.Threading.Tasks;

namespace HomeworkApi.Service
{
    public interface IAccountService : IBaseService<AccountDto, Account>
    {
        Task<BaseResponse<AccountDto>> SelfUpdateAsync(int id, AccountDto resource);
        Task<BaseResponse<AccountDto>> UpdatePasswordAsync(int id, UpdatePasswordRequest resource);
    }
}

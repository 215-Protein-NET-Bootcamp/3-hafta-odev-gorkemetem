using HomeworkApi.Base;
using System;
using System.Threading.Tasks;

namespace ProteinApi.Service
{
    public interface ITokenManagementService
    {
        Task<BaseResponse<TokenResponse>> GenerateTokensAsync(TokenRequest loginResource, DateTime now, string userAgent);
    }
}

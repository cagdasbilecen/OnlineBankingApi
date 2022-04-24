using OnlineBanking.Domain.Models.Response;

namespace OnlineBanking.Domain.Interfaces
{
    public interface IAccountBiz
    {
        void SaveAccount(SaveAccountRequest request);
        public GetAccountListResponse GetAccountList(GetAccountListRequest request);

    }
}

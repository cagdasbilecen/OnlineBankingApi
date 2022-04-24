using OnlineBanking.Domain.Models.Response;

namespace OnlineBanking.Domain.Interfaces
{
    public interface IMoneyBiz
    {
        void WithDrawMoney(WithDrawMoneyRequest request);
        void AddMoneyToAccount(AddMoneyToAccountRequest request);
    }
}

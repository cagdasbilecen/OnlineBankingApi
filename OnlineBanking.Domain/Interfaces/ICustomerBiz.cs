using OnlineBanking.Domain.Models.Response;

namespace OnlineBanking.Domain.Interfaces
{
    public interface ICustomerBiz
    {
        GetCustomerListResponse GetCustomerList();

        void SaveCustomer(SaveCustomerRequest request);

    }
}

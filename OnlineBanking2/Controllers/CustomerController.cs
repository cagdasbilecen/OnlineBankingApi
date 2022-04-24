using Microsoft.AspNetCore.Mvc;
using OnlineBanking.Api.Models;
using OnlineBanking.Api.Models.Response;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Models.Response;
using System.Collections.Generic;

namespace OnlineBanking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Dependencies
        public ICustomerBiz CustomerBiz { get; set; }
        #endregion

        #region Constructors
        public CustomerController(ICustomerBiz customerBiz)
        {
            CustomerBiz = customerBiz;
        }
        #endregion

        [HttpGet]
        [Route("get-all-customers")]
        public BaseResponseModel<GetCustomerListResponseModel> GetAllCustomers()
        {
            GetCustomerListResponse customers = CustomerBiz.GetCustomerList();

            BaseResponseModel<GetCustomerListResponseModel> result = new BaseResponseModel<GetCustomerListResponseModel>
            {
                Data = new GetCustomerListResponseModel
                {
                    CustomerList = new List<CustomerData>()
                }
            };

            foreach (var customer in customers.CustomerList)
            {
                result.Data.CustomerList.Add(new CustomerData
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    CitizenId = customer.CitizenId,
                    EmailAddress = customer.EmailAddress,
                    PhoneNumber = customer.PhoneNumber,
                    Status = customer.Status
                });
            }

            return result;
        }

        [HttpPost]
        [Route("save-customer")]
        public BaseResponseModel<object> SaveCustomer(BaseRequestModel<SaveCustomerRequestModel> request)
        {
            SaveCustomerRequest customerRequest = new SaveCustomerRequest
            {
                Name = request.Data.Name,
                Surname = request.Data.Surname,
                CitizenId = request.Data.CitizenId,
                EmailAddress = request.Data.EmailAddress,
                PhoneNumber = request.Data.PhoneNumber
            };

            CustomerBiz.SaveCustomer(customerRequest);

            BaseResponseModel<object> result = new BaseResponseModel<object>
            {
                Data = new object()
            };
            return result;

        }





        }
}

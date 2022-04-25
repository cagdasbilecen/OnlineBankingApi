using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineBanking.ApplicationConstants;
using OnlineBanking.Data.Models;
using OnlineBanking.Data.Repositories;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Models.Enum;
using OnlineBanking.Domain.Models.Response;
using OnlineBanking.Exceptions;

namespace OnlineBanking.Domain
{
    public class CustomerBiz : ICustomerBiz
    {

        private readonly IRepository repository;
        public CustomerBiz(IRepository repository)
        {
            this.repository = repository;
        }
        public GetCustomerListResponse GetCustomerList()
        {

            GetCustomerListResponse result = new GetCustomerListResponse
            {
                CustomerList = new List<CustomerResponse>()
            };
            var customers = repository.GetAll<Customer>();

            foreach (var customer in customers)
            {
                result.CustomerList.Add(new CustomerResponse
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    CitizenId = customer.CitizenId,
                    EmailAddress = customer.EmailAdress,
                    PhoneNumber = customer.PhoneNumber,
                    Status = customer.Status
                });
            }

            return result;
        }

        

        public void SaveCustomer(SaveCustomerRequest request)
        {
            CustomerResponse getCustomer = GetCustomerByCitizenId(request.CitizenId);
            if (getCustomer == null)
            {
                Customer customer = new Customer
                {
                    Name = request.Name,
                    Surname = request.Surname,
                    CitizenId = request.CitizenId,
                    EmailAdress = request.EmailAddress,
                    PhoneNumber = request.PhoneNumber,
                    Status = (int)Statuses.ACTIVE
                };

                repository.Insert(customer);
                repository.SaveChanges();
            }
            else
            {
                throw new GringottsException(GringottsExceptionTypes.SystemException, ErrorMessages.CUS_CUSTOMER_ALREADY_EXIST);
            }
        }

        private CustomerResponse GetCustomerByCitizenId(string citizenId)
        {
            Customer customer = repository.GetByFilter<Customer>(r => r.CitizenId == citizenId &&
                                                                                      r.Status == (int)Statuses.ACTIVE).FirstOrDefault();
            if (customer != null) {
                CustomerResponse result = new CustomerResponse
                {
                    Name = customer.Name,
                    Surname = customer.Surname,
                    CitizenId = customer.CitizenId,
                    EmailAddress = customer.EmailAdress,
                    PhoneNumber = customer.PhoneNumber,
                    Status = customer.Status
                };

                return result;
            }
            return null;
        }


    }
}

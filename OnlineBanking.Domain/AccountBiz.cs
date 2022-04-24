using System;
using System.Collections.Generic;
using System.Linq;
using OnlineBanking.Data.Models;
using OnlineBanking.Data.Repositories;
using OnlineBanking.Domain.Interfaces;
using OnlineBanking.Domain.Models.Enum;
using OnlineBanking.Domain.Models.Response;
using OnlineBanking.Exceptions;

namespace OnlineBanking.Domain
{
    public class AccountBiz : IAccountBiz
    {
        private readonly IRepository repository;
        public AccountBiz(IRepository repository)
        {
            this.repository = repository;
        }
        public void SaveAccount(SaveAccountRequest request)
        {

            Guid customerId = GetCustomerIdFromCitizenId(request.CitizenId);
            Account account = new Account
            {

                CustomerId = customerId,
                Description = request.Description,
                Status = (int)Statuses.ACTIVE,
                OpenedDate = DateTime.UtcNow,
                CurrentBalance = 0,
                HasOverDraft = request.HasOverDraft,
                AccountNumber = request.AccountNumber,
                BranchCode = request.BranchCode,
                BranchName = request.BranchName,
                TotalOverDraft = request.TotalOverDraft,
                CurrencyCode = request.CurrencyCode

            };

            repository.Insert(account);
            repository.SaveChanges();
        }

        public GetAccountListResponse GetAccountList(GetAccountListRequest request)
        {
            Guid customerId = GetCustomerIdFromCitizenId(request.CitizenId);
            List<Account> accountList = repository.GetByFilter<Account>(r => r.CustomerId == customerId);
            GetAccountListResponse result = new GetAccountListResponse
            {
                AccountList = new List<AccountResponse>()
            };

            foreach (var account in accountList)
            {
                result.AccountList.Add(new AccountResponse
                {
                    Status = account.Status,
                    AccountNumber = account.AccountNumber,
                    BranchCode = account.BranchCode,
                    BranchName = account.BranchName,
                    CurrencyCode = account.CurrencyCode,
                    Description = account.Description,
                    HasOverdraft = account.HasOverDraft,
                    OpenedDate = account.OpenedDate,
                    TotalOverdraft = account.TotalOverDraft,
                    CurrentBalance = account.CurrentBalance
                });
            }

            return result;
        }

        private Guid GetCustomerIdFromCitizenId(string citizenId)
        {
            Customer customer = repository.GetByFilter<Customer>(r => r.CitizenId == citizenId &&
                                                                                      r.Status == (int)Statuses.ACTIVE).FirstOrDefault();
            if (customer != null)
            {
                return customer.Id;
            }
            else
            {
                throw new GringottsException(GringottsExceptionTypes.SystemException, "CUS-001", "Customer Not Found");
            }

        }


    }
    
}

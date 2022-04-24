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
    public class MoneyBiz : IMoneyBiz
    {

        private static readonly string AddMoneyTrxDescription = "ADD_MONEY";

        private readonly IRepository Repository;
        
        public MoneyBiz(IRepository repository)
        {
            this.Repository = repository;
        }

        public void WithDrawMoney(WithDrawMoneyRequest request)
        {
            
            Account currentAccount = GetCurrentAccountFromAccountNumber(request.AccountNumber);
            long previousBalance = currentAccount.CurrentBalance;
            long newBalance = 0;
            if (currentAccount != null)
            {

                if (request.OverDraft == 0)
                {
                    if (currentAccount.CurrentBalance < request.Amount)
                    {
                        throw new GringottsException(GringottsExceptionTypes.BusinessException, ErrorMessages.MON_INSUFFICIENT_BALANCE);
                    }
                    
                    currentAccount.CurrentBalance = currentAccount.CurrentBalance - request.Amount;
                    newBalance = currentAccount.CurrentBalance;
                    Repository.Update(currentAccount);
                    Repository.SaveChanges();
                }
                if (request.OverDraft == 1)
                {
                    if (currentAccount.CurrentBalance + currentAccount.TotalOverDraft < request.Amount)
                    {
                        throw new GringottsException(GringottsExceptionTypes.BusinessException, ErrorMessages.MON_INSUFFICIENT_BALANCE);
                    }
                    if (currentAccount.CurrentBalance >= request.Amount)
                    {
                        currentAccount.CurrentBalance = currentAccount.CurrentBalance - request.Amount;
                        newBalance = currentAccount.CurrentBalance;
                        Repository.Update(currentAccount);
                        Repository.SaveChanges();
                    }
                    else if (currentAccount.CurrentBalance < request.Amount && currentAccount.CurrentBalance + currentAccount.TotalOverDraft >= request.Amount)
                    {
                        var usedOverDraftAmount = request.Amount - currentAccount.CurrentBalance;
                        currentAccount.TotalOverDraft -= usedOverDraftAmount;
                        currentAccount.CurrentBalance = 0;
                        newBalance = currentAccount.CurrentBalance;
                        Repository.Update(currentAccount);
                        Repository.SaveChanges();
                    }

                }

                SaveTransactionAfterWithDrawToDb(request, previousBalance, newBalance);

            }
            else
            {
                throw new GringottsException(GringottsExceptionTypes.SystemException, ErrorMessages.MON_ACCOUNT_NOT_FOUND);
            }
        }

        public void AddMoneyToAccount(AddMoneyToAccountRequest request)
        {
            
            Account currentAccount = GetCurrentAccountFromAccountNumber(request.AccountNumber);
            if (currentAccount != null)
            {
                if (request.Currency != currentAccount.CurrencyCode)
                {
                    throw new GringottsException(GringottsExceptionTypes.BusinessException, ErrorMessages.MON_ACCOUNT_CURRENCY_DOES_NOT_MATCH);
                }
                if (request.Amount > long.MaxValue)
                {
                    throw new GringottsException(GringottsExceptionTypes.BusinessException, ErrorMessages.TCH_TECHNICAL_ERROR);
                }
                long previousBalance = currentAccount.CurrentBalance;
                long newBalance = request.Amount + previousBalance;

                currentAccount.CurrentBalance = newBalance;
                Repository.Update(currentAccount);
                Repository.SaveChanges();

                SaveTransactionAfterWithDrawToDb(request, previousBalance, newBalance);
            }
            else
            {
                throw new GringottsException(GringottsExceptionTypes.SystemException, ErrorMessages.MON_ACCOUNT_NOT_FOUND);
            }

            
        }

        #region saveTransactionToDb overloads
        private void SaveTransactionAfterWithDrawToDb(WithDrawMoneyRequest request,long previousBalance,long newBalance)
        {
            var customerId = GetCustomerIdFromCitizenId(request.CitizenId);
            //TODO: Will be read citizenId from session.
            Transaction transaction = new Transaction
            {
                Amount = request.Amount,
                CustomerId = customerId,
                Description = request.Description,
                OverDraft = request.OverDraft,
                Status = (int)TransactionStatuses.COMPLETED,
                NewBalance = newBalance,
                PreviousBalance = previousBalance,
                AccountNumber = request.AccountNumber
            };

            Repository.Insert(transaction);
            Repository.SaveChanges();
        }

        private void SaveTransactionAfterWithDrawToDb(AddMoneyToAccountRequest request, long previousBalance, long newBalance)
        {
            var customerId = GetCustomerIdFromCitizenId(request.CitizenId);
            //TODO: Will be read citizenId from session.
            Transaction transaction = new Transaction
            {
                Amount = request.Amount,
                CustomerId = customerId,
                Description = AddMoneyTrxDescription,
                Status = (int)TransactionStatuses.COMPLETED,
                NewBalance = newBalance,
                PreviousBalance = previousBalance,
                AccountNumber = request.AccountNumber
            };

            Repository.Insert(transaction);
            Repository.SaveChanges();
        }
        #endregion

        private Guid GetCustomerIdFromCitizenId(string citizenId)
        {
            Customer customer = Repository.GetByFilter<Customer>(r => r.CitizenId == citizenId &&
                                                                                      r.Status == (int)Statuses.ACTIVE).FirstOrDefault();
            if (customer != null)
            {
                return customer.Id;
            }
            else
            {
                throw new GringottsException(GringottsExceptionTypes.SystemException, ErrorMessages.MON_CUSTOMER_NOT_FOUND);
            }

        }

        private Account GetCurrentAccountFromAccountNumber(int accountNumber)
        {
            //TODO : Create index on Account table.
            Account account = Repository.GetByFilter<Account>(r => r.AccountNumber == accountNumber).FirstOrDefault();
            return account;

        }

        
    }
    
}

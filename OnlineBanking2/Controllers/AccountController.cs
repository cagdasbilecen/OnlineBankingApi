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
    public class AccountController : ControllerBase
    {
        #region Dependencies
        public IAccountBiz AccountBiz { get; set; }
        #endregion

        #region Constructors
        public AccountController(IAccountBiz accountBiz)
        {
            AccountBiz = accountBiz;
        }
        #endregion

        [HttpPost]
        [Route("save-account")]
        public BaseResponseModel<object> SaveAccount(BaseRequestModel<SaveAccountRequestModel> request)
        {
            SaveAccountRequest accountRequest = new SaveAccountRequest
            {
                AccountNumber = request.Data.AccountNumber,
                CitizenId = request.Data.CitizenId,
                BranchCode = request.Data.BranchCode,
                BranchName = request.Data.BranchName,
                CurrencyCode = request.Data.CurrencyCode,
                Description = request.Data.Description,
                HasOverDraft = request.Data.HasOverDraft,
                TotalOverDraft = request.Data.TotalOverDraft
                
            };

            AccountBiz.SaveAccount(accountRequest);

            BaseResponseModel<object> result = new BaseResponseModel<object>
            {
                Data = new object()
            };
            return result;

        }

        [HttpGet]
        [Route("get-account-list")]
        public BaseResponseModel<GetAccountListResponseModel> GetAccountList([FromQuery(Name = "citizen_id")] string citizenId)
        {
            GetAccountListRequest accountRequest = new GetAccountListRequest
            {
                CitizenId = citizenId

            };

            GetAccountListResponse accountList = AccountBiz.GetAccountList(accountRequest);

            BaseResponseModel<GetAccountListResponseModel> result = new BaseResponseModel<GetAccountListResponseModel>
            {
                Data = new GetAccountListResponseModel
                {
                    AccountList = new List<AccountData>()
                }
            };

            foreach (var account in accountList.AccountList)
            {
                result.Data.AccountList.Add(new AccountData
                {
                    AccountNumber = account.AccountNumber,
                    BranchCode = account.BranchCode,
                    BranchName = account.BranchName,
                    CurrencyCode = account.CurrencyCode,
                    Description = account.Description,
                    CurrentBalance = account.CurrentBalance,
                    HasOverdraft = account.HasOverdraft,
                    OpenedDate = account.OpenedDate.ToString(),
                    Status = account.Status,
                    TotalOverdraft = account.TotalOverdraft
                });
            }

            return result;

        }







    }
}

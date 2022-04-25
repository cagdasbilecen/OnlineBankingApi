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
    public class MoneyController : ControllerBase
    {
        #region Dependencies
        public IMoneyBiz MoneyBiz { get; set; }
        #endregion

        #region Constructors
        public MoneyController(IMoneyBiz moneyBiz)
        {
            MoneyBiz = moneyBiz;
        }
        #endregion

        [HttpPost]
        [Route("with-draw-money")]
        public BaseResponseModel<object> WithDrawMoney(BaseRequestModel<WithDrawMoneyRequestModel> request)
        {
            WithDrawMoneyRequest withDrawRequest = new WithDrawMoneyRequest
            {
                CitizenId = request.Data.CitizenId,
                AccountNumber = request.Data.AccountNumber,
                Amount = request.Data.Amount,
                Description = request.Data.Description,
                OverDraft = request.Data.OverDraft
                
            };

            MoneyBiz.WithDrawMoney(withDrawRequest);

            BaseResponseModel<object> result = new BaseResponseModel<object>
            {
                Data = new object()
            };
            return result;

        }

        [HttpPost]
        [Route("add-money-to-account")]
        public BaseResponseModel<object> AddMoneyToAccount(BaseRequestModel<AddMoneyToAccountRequestModel> request)
        {
            AddMoneyToAccountRequest addMoneyRequest = new AddMoneyToAccountRequest
            {
                AccountNumber = request.Data.AccountNumber,
                Amount = request.Data.Amount,
                CitizenId = request.Data.CitizenId,
                Currency = request.Data.Currency
            };

            MoneyBiz.AddMoneyToAccount(addMoneyRequest);

            BaseResponseModel<object> result = new BaseResponseModel<object>
            {
                Data = new object()
            };
            return result;

        }

    }
}

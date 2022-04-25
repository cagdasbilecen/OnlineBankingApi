namespace OnlineBanking.Api.Models
{
    public class BaseErrorResponseModel : BaseResponseModel<object>
    {
        public BaseErrorResponseModel(string errorCode, string errorMessage, string detail = "")
        {
            ErrorList = new ErrorItem[1] { new ErrorItem { Code = errorCode, Message = errorMessage, Detail = detail } };
        }
    }
}

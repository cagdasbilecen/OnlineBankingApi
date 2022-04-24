namespace OnlineBanking.Api.Models
{
    public class BaseFaultResponseModel : BaseResponseModel<object>
    {
        public BaseFaultResponseModel(string infoCode, string infoMessage)
        {
            InfoList = new InfoItem[1] { new InfoItem { Code = infoCode, Message = infoMessage } };
        }
    }
}

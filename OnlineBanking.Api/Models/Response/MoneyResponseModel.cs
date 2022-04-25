using System.Text.Json.Serialization;

namespace OnlineBanking.Api.Models.Response
{
    public class MoneyResponseModel
    {
        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("amount")]
        public long Amount { get; set; }
    }
}

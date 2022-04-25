using System.Text.Json.Serialization;

namespace OnlineBanking.Api.Models
{
    public class BaseRequestModel<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
    }
}

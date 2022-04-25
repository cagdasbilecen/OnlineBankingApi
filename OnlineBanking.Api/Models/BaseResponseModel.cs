using OnlineBanking.Api.Models.Response;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace OnlineBanking.Api.Models
{
    public class BaseResponseModel<T>
    {
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("info")]
        public InfoItem[] InfoList { get; set; }
        [JsonPropertyName("errors")]
        public ErrorItem[] ErrorList { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
    public class InfoItem
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
    public class ErrorItem
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
        [JsonPropertyName("message")]
        public string Message { get; set; }
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
    }
}

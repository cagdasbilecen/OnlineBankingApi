using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OnlineBanking.Domain.Models.Response
{
    public class GetAccountListRequestModel
    {
        [JsonPropertyName("citizen_id")]
        [Required]
        public string CitizenId { get; set; }

    }
   
}

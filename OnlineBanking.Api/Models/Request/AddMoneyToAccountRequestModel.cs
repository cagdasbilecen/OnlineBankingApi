using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace OnlineBanking.Domain.Models.Response
{
    public class AddMoneyToAccountRequestModel
    {
        [JsonPropertyName("amount")]
        [Required]
        public long Amount { get; set; }
        
        [JsonPropertyName("account_number")]
        [Required]
        public int AccountNumber { get; set; }

        [JsonPropertyName("currency")]
        [Required]
        public string Currency { get; set; }
        [JsonPropertyName("citizen_id")]
        [Required]
        public string CitizenId { get; set; }

    }
   
}

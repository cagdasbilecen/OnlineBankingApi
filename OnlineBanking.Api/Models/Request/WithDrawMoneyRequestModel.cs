using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace OnlineBanking.Domain.Models.Response
{
    public class WithDrawMoneyRequestModel
    {
        [JsonPropertyName("amount")]
        [Required]
        public long Amount { get; set; }
        [JsonPropertyName("citizen_id")]
        [Required]
        public string CitizenId { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("overdraft")]
        [Required]
        public int OverDraft { get; set; }
        [JsonPropertyName("account_number")]
        [Required]
        public int AccountNumber { get; set; }
       
    }
   
}

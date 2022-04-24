using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace OnlineBanking.Domain.Models.Response
{
    public class SaveAccountRequestModel
    {
        [JsonPropertyName("citizen_id")]
        [Required]
        public string CitizenId { get; set; }
        [JsonPropertyName("description")]
        [Required]
        public string Description { get; set; }
        [JsonPropertyName("has_overdraft")]
        [Required]
        public int HasOverDraft { get; set; }
        [JsonPropertyName("total_overdraft")]
        [Required]
        public long TotalOverDraft { get; set; }
        [JsonPropertyName("account_number")]
        [Required]
        public int AccountNumber { get; set; }
        [JsonPropertyName("branch_code")]
        [Required]
        public int BranchCode { get; set; }
        [JsonPropertyName("branch_name")]
        [Required]
        public string BranchName { get; set; }
        [JsonPropertyName("currency_code")]
        [Required]
        public string CurrencyCode { get; set; }
    }
   
}

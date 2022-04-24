using OnlineBanking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace OnlineBanking.Domain.Models.Response
{
    public class GetAccountListResponseModel
    {
        [JsonPropertyName("account_list")]
        public List<AccountData> AccountList { get; set; }

    }
    public class AccountData
    {
        [JsonPropertyName("description")]
        public string Description { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
        [JsonPropertyName("opened_date")]
        public string OpenedDate { get; set; }
        [JsonPropertyName("has_over_draft")]
        public int HasOverdraft { get; set; }
        [JsonPropertyName("account_number")]
        public int AccountNumber { get; set; }
        [JsonPropertyName("branch_code")]
        public int BranchCode { get; set; }
        [JsonPropertyName("branch_name")]
        public string BranchName { get; set; }
        [JsonPropertyName("total_overdraft")]
        public long TotalOverdraft { get; set; }
        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }
        [JsonPropertyName("current_balance")]
        public long CurrentBalance { get; set; }
    }
}

using OnlineBanking.Domain.Models;
using System;
using System.Collections.Generic;


namespace OnlineBanking.Domain.Models.Response
{
    public class GetAccountListResponse
    {
        public List<AccountResponse> AccountList { get; set; }

    }
    public class AccountResponse
    {
        public string Description { get; set; }
        public int Status { get; set; }
        public DateTime OpenedDate { get; set; }
        public int HasOverdraft { get; set; }
        public int AccountNumber { get; set; }
        public int BranchCode { get; set; }
        public string BranchName { get; set; }
        public long TotalOverdraft { get; set; }
        public string CurrencyCode { get; set; }
        public long CurrentBalance { get; set; }
    }
}

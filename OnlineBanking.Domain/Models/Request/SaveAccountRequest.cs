using OnlineBanking.Domain.Models;
using System;
using System.Collections.Generic;


namespace OnlineBanking.Domain.Models.Response
{
    public class SaveAccountRequest
    {
        public string CitizenId { get; set; }
        public string Description { get; set; }
        public int HasOverDraft { get; set; }
        public int AccountNumber { get; set; }
        public int BranchCode { get; set; }
        public long TotalOverDraft { get; set; }
        public string BranchName { get; set; }
        public string CurrencyCode { get; set; }
    }
   
}

using OnlineBanking.Domain.Models;
using System;
using System.Collections.Generic;


namespace OnlineBanking.Domain.Models.Response
{
    public class WithDrawMoneyRequest
    {
        public long Amount { get; set; }
        public string CitizenId { get; set; }
        public string Description { get; set; }
        public int OverDraft { get; set; }
        public int AccountNumber { get; set; }
       
    }
   
}

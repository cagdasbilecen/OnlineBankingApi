using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace OnlineBanking.Domain.Models.Response
{
    public class AddMoneyToAccountRequest
    {

        public long Amount { get; set; }
        public int AccountNumber { get; set; }
        public string Currency { get; set; }   
        public string CitizenId { get; set; }

    }
   
}

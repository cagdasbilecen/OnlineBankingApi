using OnlineBanking.Domain.Models;
using System;
using System.Collections.Generic;


namespace OnlineBanking.Domain.Models.Response
{
    public class SaveCustomerRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CitizenId { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

    }
   
}

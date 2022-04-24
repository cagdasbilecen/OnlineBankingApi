using OnlineBanking.Data.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace OnlineBanking.Api.Models.Response
{
    public class GetCustomerListResponseModel
    {
        [JsonPropertyName("customer_list")]
        public List<CustomerData> CustomerList { get; set; }

    }
    public class CustomerData
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        public string Surname { get; set; }

        [JsonPropertyName("citizen_id")]
        public string CitizenId { get; set; }

        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }
        [JsonPropertyName("status")]
        public int Status { get; set; }
    }
}

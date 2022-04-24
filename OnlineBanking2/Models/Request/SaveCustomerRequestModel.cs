using OnlineBanking.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace OnlineBanking.Api.Models.Response
{
    public class SaveCustomerRequestModel
    {
        [JsonPropertyName("name")]
        [Required]
        public string Name { get; set; }

        [JsonPropertyName("surname")]
        [Required]
        public string Surname { get; set; }
        [Required]
        [JsonPropertyName("citizen_id")]
        public string CitizenId { get; set; }
        [Required]
        [JsonPropertyName("phone_number")]
        public string PhoneNumber { get; set; }

        [JsonPropertyName("email")]
        public string EmailAddress { get; set; }

    }
   
}

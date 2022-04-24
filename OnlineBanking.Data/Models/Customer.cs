using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Data.Models
{
    [Table("CUSTOMER")]
    public class Customer : IDomainEntity
    {
        #region IDomainEntity Members
        [Key, Required]
        [Column("ID")]
        public Guid Id { get; set; }
        [Required]
        [Column("CREATEDDATE")]
        public DateTime CreatedDate { get; set; }
        [Required]
        [Column("UPDATEDDATE")]
        public DateTime UpdatedDate { get; set; }
        #endregion

        [Required]
        [Column("NAME")]
        public string Name { get; set; }
        [Required]
        [Column("SURNAME")]
        public string Surname { get; set; }
        [Required]
        [Column("CITIZENID")]
        public string CitizenId { get; set; }
        
        [Column("EMAILADRESS")]
        public string EmailAdress { get; set; }
        [Required]
        [Column("PHONENUMBER")]
        public string PhoneNumber { get; set; }
        [Required]
        [Column("STATUS")]
        public int Status { get; set; }


    }
}

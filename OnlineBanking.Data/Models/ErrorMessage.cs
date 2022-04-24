using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Data.Models
{
    [Table("ERRORMESSAGE")]
    public class ErrorMessage : IDomainEntity
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
        [Column("APPLICATION")]
        public string Application { get; set; }
        [Required]
        [Column("LANGUAGE")]
        public string Language { get; set; }
        [Required]
        [Column("MESSAGECODE")]
        public string MessageCode { get; set; }
        [Column("MESSAGE")]
        public string Message { get; set; }


    }
}

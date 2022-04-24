using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Data.Models
{
    [Table("TRANSACTION")]
    public class Transaction : IDomainEntity
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
        [Column("CUSTOMERID")]
        public Guid CustomerId { get; set; }
        [Required]
        [Column("DESCRIPTION")]
        public string Description { get; set; }
        [Required]
        [Column("STATUS")]
        public int Status { get; set; }
        [Required]
        [Column("AMOUNT")]
        public long Amount { get; set; }

        [Column("OVERDRAFT")]
        public int OverDraft { get; set; }
        [Required]
        [Column("NEWBALANCE")]
        public long NewBalance { get; set; }
        [Required]
        [Column("PREVIOUSBALANCE")]
        public long PreviousBalance { get; set; }
        [Required]
        [Column("ACCOUNTNUMBER")]
        public int AccountNumber { get; set; }

    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnlineBanking.Data.Models
{
    [Table("ACCOUNT")]
    public class Account : IDomainEntity
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
        [Column("OPENEDDATE")]
        public DateTime OpenedDate { get; set; }
        [Required]
        [Column("CURRENTBALANCE")]
        public long CurrentBalance { get; set; }
        [Required]
        [Column("HASOVERDRAFT")]
        public int HasOverDraft { get; set; }
      
        [Column("TOTALOVERDRAFT")]
        public long TotalOverDraft { get; set; }
        [Required]
        [Column("ACCOUNTNUMBER")]
        public int AccountNumber { get; set; }
        [Required]
        [Column("BRANCHCODE")]
        public int BranchCode { get; set; }
        [Required]
        [Column("BRANCHNAME")]
        public string BranchName { get; set; }
        [Required]
        [Column("CURRENCYCODE")]
        public string CurrencyCode { get; set; }

    }
}

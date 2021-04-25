using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace CharityAccounts.Model
{
    [Table("tblCharityAccounts")]
    [Index(nameof(AccountNumber), Name = "UQ__tblChari__BE2ACD6F105F54DB", IsUnique = true)]
    //[Index(nameof(AccountNumber), Name = "UQ__tblChari__BE2ACD6FA5AA85B5", IsUnique = true)]
    public partial class TblCharityAccount
    {
        [Key]
        public int CharityAccountId { get; set; }
        public int BankId { get; set; }
        [Required]
        [StringLength(500)]
        public string BranchName { get; set; }
        [Required]
        [StringLength(1000)]
        public string OwnerName { get; set; }
        [Required]
        [StringLength(20)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(10)]
        public string AccountNumber { get; set; }
        [StringLength(500)]
        public string AccountName { get; set; }
    }
}

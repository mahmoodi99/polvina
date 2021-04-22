using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace NeedyAccounts.Model
{
    [Table("tblNeedyAccounts")]
    [Index(nameof(NeedyId), nameof(AccountNumber), nameof(ShebaNumber), Name = "UC_NeedyAccountId", IsUnique = true)]
    public partial class TblNeedyAccount
    {
        [Key]
        public int NeedyAccountId { get; set; }
        public int BankId { get; set; }
        public int NeedyId { get; set; }
        [Required]
        [StringLength(1000)]
        public string OwnerName { get; set; }
        [StringLength(10)]
        public string CardNumber { get; set; }
        [Required]
        [StringLength(20)]
        public string AccountNumber { get; set; }
        [StringLength(500)]
        public string AccountName { get; set; }
        [Required]
        [StringLength(26)]
        public string ShebaNumber { get; set; }
        
    }
}

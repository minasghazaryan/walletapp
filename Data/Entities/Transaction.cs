using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WalletApp.Data.Entities
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        [StringLength(400)]
        public string Description { get; set; }
        public DateTime SentDate { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
        public int CreateByUserId { get; set; }
        [ForeignKey("CreateByUserId")]
        public virtual ApplicationUser CreateByUser { get; set; }
        public int SendToUserId { get; set; }
        [ForeignKey("SendToUserId")]
        public virtual ApplicationUser SendToUser { get; set; }
    }
}

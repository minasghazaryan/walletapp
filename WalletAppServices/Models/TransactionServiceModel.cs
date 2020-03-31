using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletApp.WalletAppServices.Models
{
    public class TransactionServiceModel
    {        
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime SentDate { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
        public ApplicationUserServiceModel CreateByUser { get; set; }
        public ApplicationUserServiceModel SendToUser { get; set; }
        public int SentToUserId { get; set; }
    }
}

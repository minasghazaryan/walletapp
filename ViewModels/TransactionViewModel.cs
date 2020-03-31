using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WalletApp.ViewModels
{
    public class TransactionViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime SentDate { get; set; }
        public decimal Price { get; set; }
        public bool Deleted { get; set; }
        public ApplicationUserViewModel CreateByUser { get; set; }
        public string CreateByUserName { get; set; }
        public int CreateByUserId { get; set; }
        public ApplicationUserViewModel SendToUser { get; set; }
        public string SendToUserName { get; set; }
        public int SendToUserId { get; set; }
    }
}

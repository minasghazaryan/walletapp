using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WalletApp.Data.Entities
{
    public class ApplicationUser:IdentityUser<int>
    {
        
        [Required]
        [StringLength(200)]
        public string FirstName { get; set; }
        [StringLength(200)]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public decimal TotalAmount { get; set; }
        //public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<Transaction> SendedTransactions { get; set; }
        public virtual ICollection<Transaction> ResivedTransactions { get; set; }

       
    }
}

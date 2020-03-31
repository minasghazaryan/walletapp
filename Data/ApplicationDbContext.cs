using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WalletApp.Data.Entities;

namespace WalletApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {


            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().HasMany(tr => tr.ResivedTransactions).WithOne(u => u.CreateByUser).HasForeignKey(u => u.CreateByUserId).OnDelete(DeleteBehavior.Restrict);
            builder.Entity<ApplicationUser>().HasMany(tr => tr.SendedTransactions).WithOne(u => u.SendToUser).HasForeignKey(u => u.SendToUserId).OnDelete(DeleteBehavior.Restrict);
            
        }
        public virtual DbSet<Transaction> Transactions { get; set; }
    }
}

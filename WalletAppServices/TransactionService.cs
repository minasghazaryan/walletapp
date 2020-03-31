using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalletApp.Data;
using WalletApp.Data.Entities;
using WalletApp.WalletAppServices.Models;

namespace WalletApp.WalletAppServices
{
    public class TransactionService : BaseService, ITransactionService
    {
        private readonly IMapper _mapper;
        private UserManager<ApplicationUser> _userManager;
        public TransactionService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager) : base(context)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<int> Create(TransactionServiceModel model)
        {

            var entity = new Transaction
            {
                Price = model.Price,
                Description = model.Description,
                SentDate = DateTime.Now,
                CreateByUserId = model.CreateByUser.Id,
                SendToUserId = model.SendToUser.Id
            };
            await _context.Transactions.AddAsync(entity);

            int addedRows = await _context.SaveChangesAsync();
            if (addedRows > 0)
            {
                var donator = await _userManager.Users.Where(x => x.Id == entity.CreateByUserId).FirstOrDefaultAsync();
                donator.TotalAmount -= entity.Price;
                var resivedUser = await _userManager.Users.Where(x => x.Id == entity.SendToUserId).FirstOrDefaultAsync();
                resivedUser.TotalAmount += entity.Price;
                await _userManager.UpdateAsync(donator);
                await _userManager.UpdateAsync(resivedUser);

            }

            return addedRows;
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Transactions.FirstOrDefaultAsync(x => x.Id == id);
            entity.Deleted = true;
            await _context.SaveChangesAsync();
        }

        public async Task<TransactionServiceModel> GetById(int transactionId)
        {
            return await _context.Transactions.Where(x => !x.Deleted && x.Id == transactionId).Select(x => new TransactionServiceModel 
            {
                CreateByUser=new ApplicationUserServiceModel {FirstName=x.CreateByUser.FirstName },
                Description=x.Description,
                SendToUser= new ApplicationUserServiceModel { FirstName = x.SendToUser.FirstName },
                Price=x.Price,
                SentDate=x.SentDate,
                Id=x.Id
            }).FirstOrDefaultAsync();
        }

        public IQueryable<TransactionServiceModel> GetByUserId(int userId)
        {

            return _context.Transactions.Where(x => !x.Deleted && x.CreateByUserId == userId).Select(x => new TransactionServiceModel
            {
                Id = x.Id,
                Price = x.Price,
                Description = x.Description,
                SentDate = x.SentDate,
                CreateByUser = new ApplicationUserServiceModel { FirstName = x.CreateByUser.FirstName },
                SendToUser = new ApplicationUserServiceModel { FirstName = x.SendToUser.FirstName }
            });

        }
    }
}

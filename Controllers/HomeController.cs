using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using WalletApp.Data.Entities;
using WalletApp.Models;
using WalletApp.ViewModels;
using WalletApp.WalletAppServices;
using WalletApp.WalletAppServices.Models;

namespace WalletApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITransactionService _transactionService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ITransactionService transactionService, UserManager<ApplicationUser> userManager, IMapper mapper)
        {
            _logger = logger;
            _transactionService = transactionService;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Redirect("Identity/Account/Login");
            }
            //var users = await _userManager.Users.Select(x => _mapper.Map<ApplicationUserViewModel>(x)).ToListAsync();

            var transactions = await _transactionService.GetByUserId(user.Id).Select(x => _mapper.Map<TransactionViewModel>(x)).ToListAsync();

            ViewBag.user = _mapper.Map<ApplicationUserViewModel>(user);
            return View(transactions);
        }

        public async Task<IActionResult> TransactionIndex(int Id)
        {
            if (Id > 0)
            {
                var serviceModel = await _transactionService.GetById(Id);
                var model = new TransactionViewModel
                {
                    CreateByUserName = serviceModel.CreateByUser.FirstName,
                    Description = serviceModel.Description,
                    SendToUserName = serviceModel.SendToUser.FirstName,
                    Price = serviceModel.Price,
                    SentDate = serviceModel.SentDate,
                    Id = serviceModel.Id
                };
                return PartialView("_TransactionIndex", model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateTransaction()
        {
            var currentUser =await _userManager.GetUserAsync(User);
            var otherUser = _userManager.Users.Where(x => x.Id != currentUser.Id).FirstOrDefault();
            ViewBag.resiveUser = _mapper.Map<ApplicationUserViewModel>(otherUser);
            ViewBag.currUser = _mapper.Map<ApplicationUserViewModel>(currentUser);
            return PartialView("_Create");
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(TransactionViewModel model)
        {
            bool allowedAmount = false;
            var userMaxAmount = (await _userManager.GetUserAsync(User)).TotalAmount;
            if (model.Price<=userMaxAmount)
            {
                allowedAmount = true;
            }
            if (ModelState.IsValid && allowedAmount)
            {
              int addedRows=  await _transactionService.Create(_mapper.Map<TransactionServiceModel>(model));

                if (addedRows>0)
                {
                    return Json(new { success = true });

                }
                return Json(new { failed = true });

            }
            return RedirectToAction("Index");
        }
    }
}

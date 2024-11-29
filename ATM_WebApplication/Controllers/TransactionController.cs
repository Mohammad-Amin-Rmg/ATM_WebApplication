using ATM_WebApplication.Data.Context;
using ATM_WebApplication.Dto;
using ATM_WebApplication.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ATM_WebApplication.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ITransactionService _transactionService;
        private readonly ApplicationDbContext _context;
        public TransactionController(ITransactionService transactionService, ApplicationDbContext context)
        {
            _transactionService = transactionService;
            _context = context;
        }

        public IActionResult Deposit() => View();

        [HttpPost]
        public async Task<IActionResult> Deposit(TransactionDto transaction)
        {
            if (!ModelState.IsValid)
            {
                return View(transaction);
            }

            var result = await _transactionService.Deposit(transaction);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message!);
                return View(transaction);
            }

            return RedirectToAction(nameof(Balance));
        }

        public IActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Withdraw(TransactionDto transaction)
        {
            if (!ModelState.IsValid)
            {
                return View(transaction);
            }

            var result = await _transactionService.Withdraw(transaction);

            if (!result.IsSuccess)
            {
                ModelState.AddModelError("", result.Message!);
                return View(transaction);
            }

            return RedirectToAction(nameof(Balance));
        }

        public async Task<IActionResult> Balance()
        {
            var accountId = HttpContext.Session.GetInt32("AccountId");
            if (accountId == null)
            {
                return RedirectToAction("Dashboard", "Account");
            }

            var account = await _context.Accounts.FindAsync(accountId);
            if (account == null)
            {
                return RedirectToAction("Dashboard", "Account");
            }

            var balanceDto = new AccountBalanceDto
            {
                Id = account.Id,
                Balance = account.Balance,
                HolderName = account.HolderName,
            };

            return View(balanceDto);
        }

    }
}
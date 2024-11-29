using ATM_WebApplication.Data.Context;
using ATM_WebApplication.Dto;
using ATM_WebApplication.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATM_WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (ModelState.IsValid)
            {
                var account = await _context.Accounts.SingleOrDefaultAsync(x => x.Number == model.Number && x.Pin == model.Pin);

                if (account != null)
                {

                    HttpContext.Session.SetInt32("AccountId", account.Id);
                    return RedirectToAction(nameof(Dashboard));
                }

                ModelState.AddModelError("", "شماره حساب یا رمز عبور اشتباه است");
            }
            return View(model);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateAccountDto accountDto)
        {
            if (ModelState.IsValid)
            {
                var account = new Account
                {
                    Number = accountDto.Number,
                    Pin = accountDto.Pin,
                    Balance = accountDto.Balance,
                    HolderName = accountDto.HolderName,
                };

                _context.Accounts.Add(account);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Login));
            }

            return View(accountDto);
        }

        public IActionResult Dashboard()
        {
            return View();
        }
    }
}
using ATM_WebApplication.Data.Context;
using ATM_WebApplication.Dto;
using ATM_WebApplication.Models.Entities;
using ATM_WebApplication.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace ATM_WebApplication.Services;
public class TransactionService : ITransactionService
{
    private readonly ApplicationDbContext _context;

    public TransactionService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ResultDto> Withdraw(TransactionDto transaction)
    {
        var account = await GetAccountByNumberAsync(transaction.Number!);

        if (account != null)
        {
            if (account.Balance > transaction.Amount)
            {
                account.Balance -= transaction.Amount;
                _context.Transactions.Add(new Transaction
                {
                    AcountId = account.Id,
                    Amount = transaction.Amount,
                    Date = DateTime.Now,
                });
                await _context.SaveChangesAsync();

                return new ResultDto { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
            }
            else
            {
                return new ResultDto { IsSuccess = false, Message = "موجودی کافی نیست" };
            }
        }

        return new ResultDto { IsSuccess = false, Message = "حساب یافت نشد" };
    }

    public async Task<ResultDto> Deposit(TransactionDto transaction)
    {
        var account = await GetAccountByNumberAsync(transaction.Number!);

        if (account == null)
        {
            return new ResultDto { IsSuccess = false, Message = "حساب یافت نشد" };
        }

        account.Balance += transaction.Amount;
        _context.Transactions.Add(new Transaction
        {
            AcountId = account.Id,
            Amount = transaction.Amount,
            Date = DateTime.Now,
        });
        await _context.SaveChangesAsync();
        return new ResultDto { IsSuccess = true, Message = "عملیات با موفقیت انجام شد" };
    }

    public async Task<Account> GetAccountByNumberAsync(string number)
    {
        var account = await _context.Accounts.SingleOrDefaultAsync(x => x.Number == number);
        return account!;
    }
}
using ATM_WebApplication.Dto;
using ATM_WebApplication.Models.Entities;

namespace ATM_WebApplication.Services.Contract
{
    public interface ITransactionService
    {
        Task<ResultDto> Deposit(TransactionDto transaction);
        Task<ResultDto> Withdraw(TransactionDto transaction);
        Task<Account> GetAccountByNumberAsync(string number);
    }
}
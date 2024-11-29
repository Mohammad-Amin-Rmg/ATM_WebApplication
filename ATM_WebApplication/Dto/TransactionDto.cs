using System.ComponentModel.DataAnnotations;

namespace ATM_WebApplication.Dto;
public class TransactionDto
{
    [Required]
    [MinLength(9, ErrorMessage = "شماره حساب باید حداقل 9 رقم باشد.")]
    public required string Number { get; set; }

    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "مبلغ باید بزرگ تر از صفر باشد.")]
    public decimal Amount { get; set; }
}

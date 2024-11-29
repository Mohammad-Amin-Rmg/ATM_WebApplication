using System.ComponentModel.DataAnnotations;

namespace ATM_WebApplication.Dto;
public class CreateAccountDto
{
    [Required(ErrorMessage = "شماره حساب الزامی است ")]
    [StringLength(10, ErrorMessage = "شماره حساب باید 10 کاراکتر باشد")]
    public required string Number { get; set; }

    [Required(ErrorMessage = "موجودی اولیه الزامی است")]
    [Range(0, double.MaxValue, ErrorMessage = "موجودی اولیه باید عددی مثبت باشد")]
    public decimal Balance { get; set; }

    [Required(ErrorMessage = "شماره حساب الزامی است ")]
    [StringLength(30, ErrorMessage = "رمز عبور نباید بیشتر از 30 کاراکتر باشد.")]
    public required string Pin { get; set; }
    public string? HolderName { get; set; }
}


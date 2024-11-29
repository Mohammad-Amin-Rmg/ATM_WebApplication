using System.ComponentModel.DataAnnotations;

namespace ATM_WebApplication.Dto;
public class LoginDto
{
    [Required(ErrorMessage ="شماره حساب الزامی است ")]
    [StringLength(10,ErrorMessage ="شماره حساب باید 10 کاراکتر باشد")]
    public string? Number { get; set; }

    [Required(ErrorMessage ="رمز عبور الزامی است")]
    public string? Pin { get; set; }
}


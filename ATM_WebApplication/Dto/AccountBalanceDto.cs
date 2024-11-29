namespace ATM_WebApplication.Dto;
public class AccountBalanceDto
{
    public int Id { get; set; }
    public decimal Balance { get; set; }
    public string? Number { get; set; }
    public string? HolderName { get; set; }
}
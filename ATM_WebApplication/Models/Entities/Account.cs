namespace ATM_WebApplication.Models.Entities;
public class Account
{
    public int Id { get; set; }
    public required string Number { get; set; }
    public decimal Balance { get; set; }
    public string? Pin { get; set; }
    public string? HolderName { get; set; }

    public ICollection<Transaction>? Transactions { get; set; }
}


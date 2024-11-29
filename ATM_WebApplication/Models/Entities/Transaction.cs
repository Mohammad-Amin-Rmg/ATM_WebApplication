namespace ATM_WebApplication.Models.Entities;
public class Transaction
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }

    public int AcountId { get; set; }
    public Account? Account { get; set; }
}


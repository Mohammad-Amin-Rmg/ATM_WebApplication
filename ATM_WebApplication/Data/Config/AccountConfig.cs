using ATM_WebApplication.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ATM_WebApplication.Data.Config;
public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.Property(x => x.Number).HasMaxLength(16).IsRequired();
        builder.Property(x => x.Balance).HasPrecision(18, 2);
    }
}


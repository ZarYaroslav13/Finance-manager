using FinanceManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class WalletConfiguration : IEntityTypeConfiguration<Wallet>
{
    public void Configure(EntityTypeBuilder<Wallet> builder)
    {
        /// builder.HasData(DBFiller.Wallets);

        builder
            .HasOne(w => w.User)
            .WithMany(a => a.Wallets)
            .HasForeignKey(w => w.UsertId);
    }
}

using FinanceManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class FinanceOperationTypeConfiguration : IEntityTypeConfiguration<FinanceOperationType>
{
    public void Configure(EntityTypeBuilder<FinanceOperationType> builder)
    {

        //if (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") == "Development")
            //builder.HasData(DBFiller.FinanceOperationTypes);

        builder
            .HasOne(tt => tt.Wallet)
            .WithMany(w => w.FinanceOperationTypes)
            .HasForeignKey(tt => tt.WalletId);
    }
}

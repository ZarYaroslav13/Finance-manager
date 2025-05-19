using FinanceManager.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class FinanceOperationConfiguration : IEntityTypeConfiguration<FinanceOperation>
{
    public void Configure(EntityTypeBuilder<FinanceOperation> builder)
    {
        if (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") == "Development")
            builder.HasData(DBFiller.FinanceOperations);

        builder.HasOne(t => t.Type).
            WithMany(t => t.FinanceOperations).
            HasForeignKey(t => t.TypeId);
    }
}

using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class FinanceManagerUserConfiguration : IEntityTypeConfiguration<FinanceManagerUser>
{
    public void Configure(EntityTypeBuilder<FinanceManagerUser> builder)
    {
        if (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") == "Development")
            builder.HasData(DBFiller.Users);
    }
}

using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class FinanceManagerRoleConfiguration : IEntityTypeConfiguration<FinanceManagerRole>
{
    public void Configure(EntityTypeBuilder<FinanceManagerRole> builder)
    {
        //if (Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT") == "Development")
            //builder.HasData(DBFiller.Roles);
    }
}

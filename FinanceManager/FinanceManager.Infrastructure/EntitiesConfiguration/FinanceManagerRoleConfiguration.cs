using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class FinanceManagerRoleConfiguration : IEntityTypeConfiguration<FinanceManagerRole>
{
    public void Configure(EntityTypeBuilder<FinanceManagerRole> builder)
    {
            builder.HasData(DBFiller.Roles);
    }
}

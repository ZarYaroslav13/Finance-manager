using FinanceManager.Infrastructure.Models;
using FinanceManager.Infrastructure.Models.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinanceManager.Infrastructure.EntitiesConfiguration;

public class FinanceManagerUserConfiguration : IEntityTypeConfiguration<FinanceManagerUser>
{
    public void Configure(EntityTypeBuilder<FinanceManagerUser> builder)
    {
        builder.HasData(DBFiller.Users);

        builder.HasOne(u => u.Preferences)
            .WithOne(up => up.User)
            .HasForeignKey<UserPreferences>(u => u.UserId);
    }
}

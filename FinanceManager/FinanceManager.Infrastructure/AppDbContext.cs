using FinanceManager.Infrastructure.Authorization;
using Infrastructure.Authorization;
using Infrastructure.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : IdentityDbContext<APIUser, APIRole, string>
{
    public virtual DbSet<Wallet> Wallets { get; set; } = default!;
    public virtual DbSet<FinanceOperation> FinanceOperations { get; set; } = default!;
    public virtual DbSet<FinanceOperationType> FinanceOperationTypes { get; set; } = default!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach(var user in ChangeTracker.Entries<IIdentityEntity>())
        {
            switch (user.State)
            {
                case EntityState.Added:
                    {
                        user.Entity.CreatedOn = DateTime.UtcNow;
                        user.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                    }
                case EntityState.Modified:
                    {
                        user.Entity.LastModifiedOn = DateTime.UtcNow;
                        break;
                    }
            }
        }

        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        base.OnModelCreating(modelBuilder);
    }
}

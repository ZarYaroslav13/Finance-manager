namespace FinanceManager.Infrastructure.Models.Authorization;

public interface IIdentityEntity
{
    public DateTime CreatedOn { get; set; }
    public DateTime? LastModifiedOn { get; set; }
}

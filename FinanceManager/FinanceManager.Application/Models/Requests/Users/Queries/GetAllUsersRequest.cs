namespace FinanceManager.Application.Models.Requests.Users.Queries;

public class GetAllUsersRequest
{
    public int PageNumber { get; set; } = 0;

    public int Take { get; set; } = 0;
}

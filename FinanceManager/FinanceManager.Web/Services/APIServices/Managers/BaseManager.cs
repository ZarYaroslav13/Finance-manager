using FinanceManager.Web.Services.APIServices.APIHttpClient;

namespace FinanceManager.Web.Services.APIServices.Managers;

public abstract class BaseManager
{
    protected readonly IFinanceManagerApiHttpClient _httpClient;

    public BaseManager(IFinanceManagerApiHttpClient httpClient)
    {
        _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
    }
}

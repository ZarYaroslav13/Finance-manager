namespace FinanceManager.Application.UseCases.Commons.Bases;

public class BaseResponse<T>
{
    public bool Success { get; set; } = false;

    public T? Data { get; set; }

    public string? Message { get; set; }

    public IEnumerable<BaseError>? Errors { get; set; }

    public void MakeAsSuccess(string message = "")
    {
        Success = true;
        Message = message;
    }
}

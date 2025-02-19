using DotaCup.API.Enums;

namespace DotaCup.API.Models.Responses;

public class BaseResponse
{
    public bool Success { get; private set; }
    public string Error { get; private set; }

    public Guid CreatedId { get; private set; }

    private BaseResponse(bool success = true, Guid createdId = default, string error = null)
    {
        Success = success;
        Error = error;
        CreatedId = createdId;
    }

    private BaseResponse(bool success = true, string error = null)
    {
        Success = success;
        Error = error;
    }


    public static BaseResponse Succeed() => new BaseResponse(true, error: null);
    public static BaseResponse Succeed(Guid createdId) => new BaseResponse(true, createdId);
    public static BaseResponse Failed(string error) => new BaseResponse(false, error: error);
}

public class BaseResponse<T>
{
    public BaseResponse()
    {
    }

    public BaseResponse(T data, string responseMessage = null)
    {
        this.Data = data;
        this.Status = RequestExecution.Successful;
        this.ResponseMessage = responseMessage;
    }

    public BaseResponse(T data, int totalCount, string responseMessage = null)
    {
        this.Data = data;
        this.TotalCount = totalCount;
        this.Status = RequestExecution.Successful;
        this.ResponseMessage = responseMessage;
    }

    public BaseResponse(string error, List<string> errors = null)
    {
        this.Status = RequestExecution.Failed;
        this.ResponseMessage = error;
        this.Errors = errors;
    }

    public BaseResponse(T data, string error, List<string> errors, RequestExecution status)
    {
        this.Status = status;
        this.ResponseMessage = error;
        this.Errors = errors;
        this.Data = data;
    }
    public RequestExecution Status { get; set; }
    public T Data { get; set; }
    public string ResponseMessage { get; set; }
    public int TotalCount { get; set; }
    public List<string> Errors { get; set; } = new List<string>();
}

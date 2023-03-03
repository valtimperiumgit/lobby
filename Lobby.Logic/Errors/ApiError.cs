namespace Lobby.Logic.Errors;

public class ApiError : Exception
{
    public ApiError(int code, string message, List<ApiError>? errors)
    {
        Code = code;
        Message = message;
        Errors = errors;
    }

    public int Code { get; set; }
    
    public string Message { get; set; }
    
    public List<ApiError>? Errors { get; set; }

    public static ApiError NotFound(string message)
    {
        return new ApiError(404, message, null);
    }
    
    public static ApiError BadRequest(string message, List<ApiError>? errors)
    {
        return new ApiError(400, message, errors);
    }

}
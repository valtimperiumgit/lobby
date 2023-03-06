using System.Net;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Lobby.Logic.Errors;

public class ApiError : Exception
{
    public ApiError(HttpStatusCode code, string message, List<ApiError>? errors)
    {
        Code = code;
        Message = message;
        Errors = errors;
    }

    public ApiError()
    {
        Code = HttpStatusCode.InternalServerError;
        Message = "Server error";
    }

    public HttpStatusCode Code { get; set; }
    
    public string Message { get; set; }
    
    public List<ApiError>? Errors { get; set; }
    
    [JsonIgnore]
    public MethodBase TargetSite { get; set; }

    public static ApiError NotFound(string message)
    {
        return new ApiError(HttpStatusCode.NotFound, message, null);
    }
    
    public static ApiError BadRequest(string message, List<ApiError>? errors)
    {
        return new ApiError(HttpStatusCode.BadRequest, message, errors);
    }

}
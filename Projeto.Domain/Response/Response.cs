public class Response<TData>
{
    public TData? Data { get; set; }
    public string? Message { get; set; }
    public bool Success { get; set; } = true;
    public List<string>? Errors { get; set; }

    public Response() {}

    public Response(TData data, string message = "", bool success = true)
    {
        Data = data;
        Message = message;
        Success = success;
    }

    public Response(List<string> errors, string message = "")
    {
        Success = false;
        Errors = errors;
        Message = message;
    }
}

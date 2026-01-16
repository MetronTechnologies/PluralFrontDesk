namespace FrontDeskApp.Application.Common
{
    public class ResponseInfo<T>
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }
        public T? Data { get; private set; }

        public ResponseInfo() { }

        public ResponseInfo<T> MarkSuccess(T? data, string? message = null)
        {
            Success = true;
            Data = data;
            Message = message;
            return this;
        }

        public ResponseInfo<T> MarkFail(string message)
        {
            Success = false;
            Data = default;
            Message = message;
            return this;
        }
    }

    public class ResponseInfo
    {
        public bool Success { get; private set; }
        public string? Message { get; private set; }

        public ResponseInfo() { }

        public ResponseInfo MarkSuccess(string? message = null)
        {
            Success = true;
            Message = message;
            return this;
        }

        public ResponseInfo MarkFail(string message)
        {
            Success = false;
            Message = message;
            return this;
        }
    }
}
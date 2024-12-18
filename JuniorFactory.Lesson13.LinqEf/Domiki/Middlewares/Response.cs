namespace Domiki.Web
{
    public class Response<T> : Response
    {
        public T Content { get; set; }

        public Response(T content)
        {
            Content = content;
        }
    }

    public class Response
    {
        public ResponseType Type { get; set; }
        public Response()
        {
            Type = ResponseType.Success;
        }
    }

    public enum ResponseType
    {
        Success = 1,
        ErrorMessage = 2,
    }
}

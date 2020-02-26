namespace Company.Services.Middlewares
{
    public class Error
    {
        public int HttpStatusCode { get; set; }
        public string EventId { get; set; }
        public string Method { get; set; }
        public string Message { get; set; }
    }
}

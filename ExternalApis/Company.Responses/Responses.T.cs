namespace Company.Responses
{
    public class Response<TResponse>
    {
        public Response(Result result)
        {
            Result = result;
        }

        public Response(Result result, string description) : this(result)
        {
            Description = description;
        }

        public TResponse Data { get; set; }

        public Result Result { get; set; }

        public string Description { get; set; }
    }
}

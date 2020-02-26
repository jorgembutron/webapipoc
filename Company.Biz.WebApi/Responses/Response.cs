using System;

namespace Company.Biz.WebApi.Responses
{
    /// <summary>
    /// 
    /// </summary>
    //[Obsolete]
    public class Response
    {
        public Response(Result result)
        {
            Result = result;
        }

        public Response(Result result, string description) : this(result)
        {
            Description = description;
        }

        public Result Result { get; set; }

        public string Description { get; set; }
    }

   

}

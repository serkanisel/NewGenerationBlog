using System;
using System.Net;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;

namespace NewGenerationBlog.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(string message,HttpStatusCode httpStatusCode=HttpStatusCode.OK)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
        }

        public Result(string message,string exception,HttpStatusCode httpStatusCode=HttpStatusCode.OK)
        {
            HttpStatusCode = httpStatusCode;
            Message = message;
            ErrorMessage = exception;
        }

        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get; }

        public string ErrorMessage { get; }
     }
}

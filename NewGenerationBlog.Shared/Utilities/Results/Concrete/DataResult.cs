using System;
using System.Net;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;

namespace NewGenerationBlog.Shared.Utilities.Results.Concrete
{
    public class DataResult<T> : IDataResult<T>
    {
        public DataResult(T data,HttpStatusCode httpStatusCode=HttpStatusCode.OK)
        {
            Data = data;
        }

        public DataResult(string message, T data, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
            Message = message;
        }

        public DataResult(string message, T data, string errorMessage, HttpStatusCode httpStatusCode = HttpStatusCode.OK)
        {
            HttpStatusCode = httpStatusCode;
            Data = data;
            Message = message;
            ErrorMessage = errorMessage;
        }

        public T Data { get; }


        public string Message { get; }

        public string ErrorMessage { get; }

        public HttpStatusCode HttpStatusCode { get; set; }
    }
}

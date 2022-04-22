using System;
using NewGenerationBlog.Shared.Utilities.Results.Abstract;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;

namespace NewGenerationBlog.Shared.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public Result(ResultStatus resultStatus,string message)
        {
            ResultStatus = resultStatus;
            Message = message;

        }

        public Result(ResultStatus resultStatus, string message,string exception)
        {
            ResultStatus = resultStatus;
            Message = message;
            ErrorMessage = exception;
        }

        public ResultStatus ResultStatus { get; }

        public string Message { get; }

        public string ErrorMessage { get; }
     }
}

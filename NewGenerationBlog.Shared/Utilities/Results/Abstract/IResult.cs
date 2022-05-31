using System;
using System.Net;
using NewGenerationBlog.Shared.Utilities.Results.ComplextTypes;

namespace NewGenerationBlog.Shared.Utilities.Results.Abstract
{
    public interface IResult
    {
        public HttpStatusCode HttpStatusCode { get; set; }

        public string Message { get;  }

        public string ErrorMessage { get; }
    }
}

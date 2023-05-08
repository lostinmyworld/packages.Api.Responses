using packages.Api.Responses.Enums;
using System;

namespace packages.Api.Responses
{
    public class Response<T>
        where T : class
    {
        public Guid? ResponseKey { get; set; } = Guid.NewGuid();
        public ResponseCode ResponseCode { get; set; } = ResponseCode.Ambiguous;
        public T? Payload { get; set; } = null;
        public ProblemDetailsSimple? ProblemDetails { get; set; } = null;
    }
}

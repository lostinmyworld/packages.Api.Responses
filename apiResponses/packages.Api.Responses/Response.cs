using Microsoft.AspNetCore.Mvc;
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
        public ProblemDetails? ProblemDetails { get; set; } = null;
    }
}

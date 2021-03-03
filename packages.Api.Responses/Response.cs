using Microsoft.AspNetCore.Mvc;
using packages.Api.Enums;
using System;

namespace packages.Api.Responses
{
    public class Response<T>
    {
        public Guid? ResponseKey { get; set; } = Guid.NewGuid();
        public ResponseCode ResponseCode { get; set; }
        public T Payload { get; set; }
        public ProblemDetails ProblemDetails { get; set; }
    }
}

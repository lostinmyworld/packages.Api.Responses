using packages.Api.Responses.Enums;
using System.Net;
using System.Net.Http;

namespace packages.Api.Responses.Consumer
{
    internal static class Extensions
    {
        private static readonly ProblemDetailsSimple _problemDetailsSuccess = new()
        {
            Title = "Success",
            Detail = "Resource was retrieved successfully",
            Status = HttpStatusCode.OK
        };
        private static readonly ProblemDetailsSimple _problemDetailsNotFound = new()
        {
            Title = "Resouce not found",
            Detail = "Cannot find the resource you requested",
            Status = HttpStatusCode.NotFound
        };
        private static readonly ProblemDetailsSimple _problemDetailsInternalServerError = new()
        {
            Title = "Unhandled error",
            Detail = "Unhandled error occurred!",
            Status = HttpStatusCode.InternalServerError
        };

        internal static ProblemDetailsSimple RetrieveProblemDetails(this HttpResponseMessage responseMsg)
        {
            if (responseMsg.IsSuccessStatusCode)
            {
                return _problemDetailsSuccess;
            }
            if (responseMsg.StatusCode == HttpStatusCode.NotFound)
            {
                return _problemDetailsNotFound;
            }

            return _problemDetailsInternalServerError;
        }

        internal static ResponseCode RetrieveResponseCode(this HttpResponseMessage responseMsg)
        {
            if (responseMsg.IsSuccessStatusCode || responseMsg.StatusCode == HttpStatusCode.NotFound)
            {
                return ResponseCode.Valid;
            }
            if (responseMsg.StatusCode == HttpStatusCode.InternalServerError)
            {
                return ResponseCode.Invalid;
            }

            return ResponseCode.Ambiguous;
        }
    }
}

using packages.Api.Responses.Enums;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace packages.Api.Responses.Consumer
{
    public static class Consumer
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

        private static async Task<RetrieveGamesResponse> RetrieveGames()
        {
            var client = new HttpClient();
            using var responseMsg = await client.GetAsync("http://example.com");
            var responseContent = await responseMsg.Content.ReadAsStringAsync();

            var response = JsonSerializer.Deserialize<List<Game>>(responseContent);

            return new RetrieveGamesResponse
            {
                Payload = response,
                ProblemDetails = responseMsg.RetrieveProblemDetails(),
                ResponseCode = responseMsg.RetrieveResponseCode(),
                ResponseKey = Guid.NewGuid()
            };
        }

        private static ProblemDetailsSimple RetrieveProblemDetails(this HttpResponseMessage responseMsg)
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

        private static ResponseCode RetrieveResponseCode(this HttpResponseMessage responseMsg)
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
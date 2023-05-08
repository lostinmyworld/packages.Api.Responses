using packages.Api.Responses.Enums;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace packages.Api.Responses.Consumer
{
    public class Consumer
    {
        internal async Task<RetrieveGamesResponse> RetrieveGames(string url)
        {
            var client = new HttpClient();
            using var responseMsg = await client.GetAsync(url);
            var responseContent = await responseMsg.Content.ReadAsStringAsync();

            var responsePayload = new List<Game>();
            var defaultProblemDetails = new ProblemDetailsSimple
            {
                Title = "Not expected",
                Status = responseMsg.StatusCode,
                Detail = "Response was not expected"
            };
            var isSuccess = responseMsg.IsSuccessStatusCode;

            try
            {
                responsePayload = JsonSerializer.Deserialize<List<Game>>(responseContent);
            }
            catch
            {
                isSuccess = false;
            }

            return new RetrieveGamesResponse
            {
                Payload = responsePayload,
                ProblemDetails = isSuccess
                    ? responseMsg.RetrieveProblemDetails()
                    : defaultProblemDetails,
                ResponseCode = isSuccess
                    ? responseMsg.RetrieveResponseCode()
                    : ResponseCode.Invalid,
                ResponseKey = Guid.NewGuid()
            };
        }
    }
}
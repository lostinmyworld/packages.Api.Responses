using packages.Api.Responses.Consumer;
using System;
using System.Text.Json;

Console.WriteLine("###### Consumer started ######");

var consumer = new Consumer();

var response = await consumer.RetrieveGames("http://example.com");

Console.WriteLine($"ResponseCode: {response.ResponseCode}");
Console.WriteLine($"Payload: {JsonSerializer.Serialize(response.Payload)}");
Console.WriteLine($"ProblemDetails: {JsonSerializer.Serialize(response.ProblemDetails)}");
Console.WriteLine($"ResponseKey: {response.ResponseKey}");
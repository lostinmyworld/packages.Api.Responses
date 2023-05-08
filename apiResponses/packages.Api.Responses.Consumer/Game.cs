using System;

namespace packages.Api.Responses.Consumer
{
    internal class Game
    {
        public Guid? Id { get; set; }
        public string? GameId { get; set; }
        public decimal? AverageReview { get; set; }
    }
}

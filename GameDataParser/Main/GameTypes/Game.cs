using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameDataParser.Main.GameTypes
{
    public class Game
    {

        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("ReleaseYear")]
        public int ReleaseYear { get; set; }

        [JsonPropertyName("Rating")]

        public double Rating { get; set; }


        public override string ToString() =>
            $"{Title}, " +
            $"release in {ReleaseYear.ToString()}, " +
            $"rating:{Rating.ToString()}";

    }
}

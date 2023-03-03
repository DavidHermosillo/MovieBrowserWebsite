using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieBrowser.Website.Models
{
    public class Movie
    {
        public string Title { get; set; }
        public string Year { get; set; }

        [JsonPropertyName("imdbID")]
        public string Id { get; set; }

        public string Type { get; set; }
        public string Poster { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize<Movie>(this);
        }
    }
}

using System.Text.Json.Serialization;

namespace MovieBrowser.Website.Models
{
    public class Search
    {        
        public string Response { get; set; }

        [JsonPropertyName("Search")]
        public IList<Movie>? SearchResult { get; set; }

        public string totalResults { get; set; }
    }
}

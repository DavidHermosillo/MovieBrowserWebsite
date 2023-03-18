using MovieBrowser.Website.Models;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MovieBrowser.Website.Services
{
    public class MockDataMovieService
    {
        public IWebHostEnvironment WebHostEnvironment { get;  }
        public MockDataMovieService(IWebHostEnvironment webHostEnvironment) {
            WebHostEnvironment = webHostEnvironment;
        }

        private string MockDataFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "MockData.json"); }
        }

        public IEnumerable<Movie> GetMovies()
        {
            string jsonString = File.ReadAllText(MockDataFileName);
            Search search = JsonSerializer.Deserialize<Search>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return search.SearchResult;
        }

        private string MockMovieDetailsFileName
        {
            get { return Path.Combine(WebHostEnvironment.WebRootPath, "data", "MockMovie.json"); }
        }

        public MovieDetails GetDetails(string movieId)
        {
            string jsonString = File.ReadAllText(MockMovieDetailsFileName);
            return JsonSerializer.Deserialize<MovieDetails>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}

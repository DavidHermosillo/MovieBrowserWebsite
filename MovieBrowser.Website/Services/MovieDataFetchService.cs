using MovieBrowser.Website.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace MovieBrowser.Website.Services
{
    public class MovieDataFetchService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }
        public MovieDataFetchService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public MovieDetails getDetails(string movieId)
        {
            MovieDetails movie;
            HttpClient request = new HttpClient();
            request.DefaultRequestHeaders.Add("User-Agent", "Anything");
            request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = request.GetAsync("http://www.omdbapi.com/?apikey=6f9ef35f&i=" + movieId).Result;
            response.EnsureSuccessStatusCode();
            string json = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<MovieDetails>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        public Search GetMoviesList(string input)
        {
            HttpClient request = new HttpClient();
            request.DefaultRequestHeaders.Add("User-Agent", "Anything");
            request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = request.GetAsync("http://www.omdbapi.com/?apikey=6f9ef35f&s=" + input).Result;
            response.EnsureSuccessStatusCode();
            string json = response.Content.ReadAsStringAsync().Result;
            Search search = JsonSerializer.Deserialize<Search>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return search;
        }

        public Search getDifferentPage(string input, int page)
        {
            HttpClient request = new HttpClient();
            request.DefaultRequestHeaders.Add("User-Agent", "Anything");
            request.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var response = request.GetAsync("http://www.omdbapi.com/?apikey=6f9ef35f&s=" + input + "&page=" + page).Result;
            response.EnsureSuccessStatusCode();
            string json = response.Content.ReadAsStringAsync().Result;
            Search search = JsonSerializer.Deserialize<Search>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            return search;
        }
    }
}

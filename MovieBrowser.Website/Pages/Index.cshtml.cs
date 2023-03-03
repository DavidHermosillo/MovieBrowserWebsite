using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MovieBrowser.Website.Models;
using MovieBrowser.Website.Services;

namespace MovieBrowser.Website.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public MockDataMovieService MovieService { get; set; }
        public IEnumerable<Movie> Movies { get; private set; }

        public IndexModel(ILogger<IndexModel> logger, MockDataMovieService movieService)
        {
            _logger = logger;
            MovieService = movieService;
        }

        public void OnGet()
        {
            Movies = MovieService.GetMovies();
        }
    }
}
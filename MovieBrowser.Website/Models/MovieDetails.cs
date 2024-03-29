﻿using System.Text.Json.Serialization;

namespace MovieBrowser.Website.Models
{
    public class MovieDetails
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Rated { get; set; }
        [JsonPropertyName("Released")]
        public string ReleaseDate { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Poster { get; set; }

    }
}

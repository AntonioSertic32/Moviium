using MoviesCoreAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCoreAPI.ViewModel
{
    public class MoviesViewModel
    {
        public int MovieID { get; set; }
        public string Title { get; set; }
        public string Released { get; set; }
        public string Runtime { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
        public string Language { get; set; }
        public string Awards { get; set; }
        public string Poster { get; set; }
        public string Metascore { get; set; }
        public string ImdbRating { get; set; }
        public string Production { get; set; }

        public static implicit operator MoviesViewModel(Movies movie)
        {
            return new MoviesViewModel
            {
                MovieID = movie.MovieID,
                Title = movie.Title,
                Released = movie.Released,
                Runtime = movie.Runtime,
                Genre = movie.Genre,
                Director = movie.Director,
                Writer = movie.Writer,
                Actors = movie.Actors,
                Plot = movie.Plot,
                Language = movie.Language,
                Awards = movie.Awards,
                Poster = movie.Poster,
                Metascore = movie.Metascore,
                ImdbRating = movie.ImdbRating,
                Production = movie.Production

            };
        }

        public static implicit operator Movies(MoviesViewModel movieViewModel)
        {
            return new Movies
            {
                MovieID = movieViewModel.MovieID,
                Title = movieViewModel.Title,
                Released = movieViewModel.Released,
                Runtime = movieViewModel.Runtime,
                Genre = movieViewModel.Genre,
                Director = movieViewModel.Director,
                Writer = movieViewModel.Writer,
                Actors = movieViewModel.Actors,
                Plot = movieViewModel.Plot,
                Language = movieViewModel.Language,
                Awards = movieViewModel.Awards,
                Poster = movieViewModel.Poster,
                Metascore = movieViewModel.Metascore,
                ImdbRating = movieViewModel.ImdbRating,
                Production = movieViewModel.Production
            };
        }
    }
}

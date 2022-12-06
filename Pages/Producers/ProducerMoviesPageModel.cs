using MegansMatineeX.Data;
using MegansMatineeX.Models;
using MegansMatineeX.Models.MovieViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MegansMatineeX.Pages.Producers
{
    public class ProducerMoviesPageModel : PageModel
    {
        public List<AssignedMovieData> AssignedMovieDataList;

        public void PopulateAssignedMovieData(MegansMatineeXContext context,
                                               Producer producer)
        {
            var allMovies = context.Movies;
            var producerMovies = new HashSet<int>(
                producer.Movies.Select(c => c.MovieID));
            AssignedMovieDataList = new List<AssignedMovieData>();
            foreach (var movie in allMovies)
            {
                AssignedMovieDataList.Add(new AssignedMovieData
                {
                    MovieID = movie.MovieID,
                    Title = movie.Title,
                    Assigned = producerMovies.Contains(movie.MovieID)
                });
            }
        }
    }
}

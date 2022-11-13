using MegansMatineeX.Data;
using MegansMatineeX.Models;
using MegansMatineeX.Models.MovieViewModels;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace MegansMatineeX.Pages.LeadActs
{
    public class LeadActMoviesPageModel
    {
        public List<AssignedMovieData> AssignedMovieDataList;

        public void PopulateAssignedMovieData(MegansMatineeXContext context,
                                               LeadAct leadact)
        {
            var allMovies = context.Movies;
            var LeadActMovies = new HashSet<int>(
                leadact.MovieCasts.Select(c => c.MovieID));
            AssignedMovieDataList = new List<AssignedMovieData>();
            foreach (var movie in allMovies)
            {
                AssignedMovieDataList.Add(new AssignedMovieData
                {
                    MovieID = movie.MovieID,
                    Title = movie.Title,
                    //Assigned = leadactMovies.Contains(movie.MovieID)
                });
            }
        }
    }
}

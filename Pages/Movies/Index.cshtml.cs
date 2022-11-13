using MegansMatineeX.Data;
using MegansMatineeX.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MegansMatineeX.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly MegansMatineeXContext _context;
        private readonly IConfiguration Configuration;

        public IndexModel(MegansMatineeXContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        public string TitleSort { get; set; }
        public string DateSort { get; set; }

        public string GenreSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Movie> Movies { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            TitleSort = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            GenreSort = sortOrder == "Genre" ? "genre_desc" : "Genre";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Movie> moviesIQ = from s in _context.Movies
                                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                moviesIQ = moviesIQ.Where(s => s.Title.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "title_desc":
                    moviesIQ = moviesIQ.OrderByDescending(s => s.Title);
                    break;
                case "Date":
                    moviesIQ = moviesIQ.OrderBy(s => s.ReleaseDate);
                    break;
                case "Genre":
                    moviesIQ = moviesIQ.OrderBy(s => s.Genre);
                    break;
                case "genre_desc":
                    moviesIQ = moviesIQ.OrderByDescending(s => s.Genre);
                    break;
                case "date_desc":
                    moviesIQ = moviesIQ.OrderByDescending(s => s.ReleaseDate);
                    break;
                default:
                    moviesIQ = moviesIQ.OrderBy(s => s.Title);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Movies = await PaginatedList<Movie>.CreateAsync(
                moviesIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
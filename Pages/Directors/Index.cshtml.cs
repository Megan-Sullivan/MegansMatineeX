using MegansMatineeX.Data;
using MegansMatineeX.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MegansMatineeX.Pages.Directors
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

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Director> Directors { get; set; }

        public async Task OnGetAsync(string sortOrder,
            string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Director> directorsIQ = from s in _context.Directors
                                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                directorsIQ = directorsIQ.Where(s => s.DirectorName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    directorsIQ = directorsIQ.OrderByDescending(s => s.DirectorName);
                    break;
                case "Date":
                    directorsIQ = directorsIQ.OrderBy(s => s.Birthdate);
                    break;
                case "date_desc":
                    directorsIQ = directorsIQ.OrderByDescending(s => s.Birthdate);
                    break;
                default:
                    directorsIQ = directorsIQ.OrderBy(s => s.DirectorName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            Directors = await PaginatedList<Director>.CreateAsync(
                directorsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
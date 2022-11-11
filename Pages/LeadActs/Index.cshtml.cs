using MegansMatineeX.Data;
using MegansMatineeX.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MegansMatineeX.Pages.LeadActs
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

        public PaginatedList<LeadAct> LeadActs { get; set; }

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

            IQueryable<LeadAct> leadactsIQ = from s in _context.LeadActs
                                               select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                leadactsIQ = leadactsIQ.Where(s => s.LeadActName.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    leadactsIQ = leadactsIQ.OrderByDescending(s => s.LeadActName);
                    break;
                case "Date":
                    leadactsIQ = leadactsIQ.OrderBy(s => s.Birthdate);
                    break;
                case "date_desc":
                    leadactsIQ = leadactsIQ.OrderByDescending(s => s.Birthdate);
                    break;
                default:
                    leadactsIQ = leadactsIQ.OrderBy(s => s.LeadActName);
                    break;
            }

            var pageSize = Configuration.GetValue("PageSize", 4);
            LeadActs = await PaginatedList<LeadAct>.CreateAsync(
                leadactsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
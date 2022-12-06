using MegansMatineeX.Models.MovieViewModels;
using MegansMatineeX.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MegansMatineeX.Models;

namespace MegansMatineeX.Pages
{
    public class AboutModel : PageModel
    {
        private readonly MegansMatineeXContext _context;

        public AboutModel(MegansMatineeXContext context)
        {
            _context = context;
        }
        
        public IList<MovieCastDateGroup> LeadActs { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<MovieCastDateGroup> data =
                from leadact in _context.LeadActs
                group leadact by leadact.Birthdate into dateGroup
                select new MovieCastDateGroup()
                {
                    MovieCastDate = dateGroup.Key,
                    LeadActCount = dateGroup.Count()
                };

            LeadActs = await data.AsNoTracking().ToListAsync();
        }
        
        public IList<MovieDirectorDateGroup> Directors { get; set; }
        
        public async Task OnGetAsync2()
        {
            IQueryable<MovieDirectorDateGroup> data =
                from director in _context.Directors
                group director by director.Birthdate into dateGroup
                select new MovieDirectorDateGroup()
                {
                    MovieDirectorDate = dateGroup.Key,
                    DirectorCount = dateGroup.Count()
                };

            Directors = await data.AsNoTracking().ToListAsync();
        }
        
    }
}
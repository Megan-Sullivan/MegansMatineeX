using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegansMatineeX.Data;
using MegansMatineeX.Models;

namespace MegansMatineeX.Pages.Directors
{
    public class DetailsModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public DetailsModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

      public Director Director { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            Director = await _context.Directors
                .Include(s => s.MovieDirectors)
                .ThenInclude(e => e.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            //var director = await _context.Directors.FirstOrDefaultAsync(m => m.ID == id);
            if (Director == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

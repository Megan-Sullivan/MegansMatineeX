using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegansMatineeX.Data;
using MegansMatineeX.Models;
using Microsoft.AspNetCore.Authorization;

namespace MegansMatineeX.Pages.Movies
{
    [Authorize]
    public class DetailsModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public DetailsModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

      public Movie Movie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            //var movie = await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == id);

            Movie = await _context.Movies
                .AsNoTracking()
                .Include(c => c.Production)
                .FirstOrDefaultAsync(m => m.MovieID == id);

            if (Movie == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

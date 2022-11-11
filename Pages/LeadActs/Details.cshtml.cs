using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegansMatineeX.Data;
using MegansMatineeX.Models;

namespace MegansMatineeX.Pages.LeadActs
{
    public class DetailsModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public DetailsModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

      public LeadAct LeadAct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeadActs == null)
            {
                return NotFound();
            }

            LeadAct = await _context.LeadActs
                .Include(s => s.MovieCasts)
                .ThenInclude(e => e.Movie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            //var leadact = await _context.LeadActs.FirstOrDefaultAsync(m => m.ID == id);
            if (LeadAct == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

/*
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
    public class DeleteModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public DeleteModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        [BindProperty]
      public LeadAct LeadAct { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeadActs == null)
            {
                return NotFound();
            }

            var leadact = await _context.LeadActs.FirstOrDefaultAsync(m => m.ID == id);

            if (leadact == null)
            {
                return NotFound();
            }
            else 
            {
                LeadAct = leadact;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.LeadActs == null)
            {
                return NotFound();
            }
            var leadact = await _context.LeadActs.FindAsync(id);

            if (leadact != null)
            {
                LeadAct = leadact;
                _context.LeadActs.Remove(LeadAct);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
*/

using MegansMatineeX.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace MegansMatineeX.Pages.LeadActs
{
    public class DeleteModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(MegansMatineeX.Data.MegansMatineeXContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public LeadAct LeadAct { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            LeadAct = await _context.LeadActs
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (LeadAct == null)
            {
                return NotFound();
            }

            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leadact = await _context.LeadActs.FindAsync(id);

            if (leadact == null)
            {
                return NotFound();
            }

            try
            {
                _context.LeadActs.Remove(leadact);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}
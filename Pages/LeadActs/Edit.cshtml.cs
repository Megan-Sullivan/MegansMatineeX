using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegansMatineeX.Data;
using MegansMatineeX.Models;

namespace MegansMatineeX.Pages.LeadActs
{
    public class EditModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public EditModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LeadAct LeadAct { get; set; } = default!;

        /*
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.LeadActs == null)
            {
                return NotFound();
            }

            var leadact =  await _context.LeadActs.FirstOrDefaultAsync(m => m.ID == id);
            if (leadact == null)
            {
                return NotFound();
            }
            LeadAct = leadact;
            return Page();
        }
        */

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            LeadAct = await _context.LeadActs.FindAsync(id);

            if (LeadAct == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.

        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(LeadAct).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LeadActExists(LeadAct.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        */
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var leadactToUpdate = await _context.LeadActs.FindAsync(id);

            if (leadactToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<LeadAct>(
                leadactToUpdate,
                "director",
                s => s.LeadActName, s => s.Birthdate, s => s.LeadActDetails, s => s.AdditionalInfo))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool LeadActExists(int id)
        {
          return _context.LeadActs.Any(e => e.ID == id);
        }
    }
}

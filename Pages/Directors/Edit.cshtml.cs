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

namespace MegansMatineeX.Pages.Directors
{
    public class EditModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public EditModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Director Director { get; set; } = default!;

        /*
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            var director =  await _context.Directors.FirstOrDefaultAsync(m => m.ID == id);
            if (director == null)
            {
                return NotFound();
            }
            Director = director;
            return Page();
        }
        */

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Director = await _context.Directors.FindAsync(id);

            if (Director == null)
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

            _context.Attach(Director).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DirectorExists(Director.ID))
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
            var directorToUpdate = await _context.Directors.FindAsync(id);

            if (directorToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Director>(
                directorToUpdate,
                "director",
                s => s.DirectorName, s => s.Birthdate, s => s.DirectorDetails, s => s.AdditionalInfo))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool DirectorExists(int id)
        {
            return _context.Directors.Any(e => e.ID == id);
        }
    }
}

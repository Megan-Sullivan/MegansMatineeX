using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegansMatineeX.Data;
using MegansMatineeX.Models;

namespace MegansMatineeX.Pages.Directors
{
    public class CreateModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public CreateModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Director Director { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /*
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
        */
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyDirector = new Director();

            if (await TryUpdateModelAsync<Director>(
                emptyDirector,
                "director",   // Prefix for form value.
                s => s.DirectorName, s => s.Birthdate, s => s.DirectorDetails, s => s.AdditionalInfo))
            {
                _context.Directors.Add(emptyDirector);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
            }
        /*
            _context.Directors.Add(Director);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        */
        
    }
}

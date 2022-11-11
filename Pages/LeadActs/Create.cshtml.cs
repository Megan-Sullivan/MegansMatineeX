using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegansMatineeX.Data;
using MegansMatineeX.Models;

namespace MegansMatineeX.Pages.LeadActs
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
        public LeadAct LeadAct { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        /*
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.LeadActs.Add(LeadAct);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        */
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyLeadAct = new LeadAct();

            if (await TryUpdateModelAsync<LeadAct>(
                emptyLeadAct,
                "leadact",   // Prefix for form value.
                s => s.LeadActName, s => s.Birthdate, s => s.LeadActDetails, s => s.AdditionalInfo))
            {
                _context.LeadActs.Add(emptyLeadAct);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}

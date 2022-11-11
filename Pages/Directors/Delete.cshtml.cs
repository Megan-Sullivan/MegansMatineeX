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

namespace MegansMatineeX.Pages.Directors
{
    public class DeleteModel : PageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public DeleteModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Director Director { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }

            var director = await _context.Directors.FirstOrDefaultAsync(m => m.ID == id);

            if (director == null)
            {
                return NotFound();
            }
            else 
            {
                Director = director;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Directors == null)
            {
                return NotFound();
            }
            var director = await _context.Directors.FindAsync(id);

            if (director != null)
            {
                Director = director;
                _context.Directors.Remove(Director);
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

namespace MegansMatineeX.Pages.Directors
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
        public Director Director { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Director = await _context.Directors
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Director == null)
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

            var director = await _context.Directors.FindAsync(id);

            if (director == null)
            {
                return NotFound();
            }

            try
            {
                _context.Directors.Remove(director);
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
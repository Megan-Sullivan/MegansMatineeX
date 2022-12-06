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
using Microsoft.AspNetCore.Authorization;

namespace MegansMatineeX.Pages.Movies
{
    //[Authorize(Roles = "Admin, Critic")]
    [AllowAnonymous]
    public class EditModel : ProductionNamePageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public EditModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Movies == null)
            {
                return NotFound();
            }

            //var movie =  await _context.Movies.FirstOrDefaultAsync(m => m.MovieID == id);
            Movie = await _context.Movies
                .Include(c => c.Production).FirstOrDefaultAsync(m => m.ProductionID == id);
            
            if (Movie == null)
            {
                return NotFound();
            }
            /*
            Movie = movie;
            */
            // Select current ProductionID.
            PopulateProductionsDropDownList(_context, Movie.ProductionID);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movieToUpdate = await _context.Movies.FindAsync(id);

            if (movieToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Movie>(
                 movieToUpdate,
                 "movie",   // Prefix for form value.
                   c => c.ProductionID, c => c.Title))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select ProductionID if TryUpdateModelAsync fails.
            PopulateProductionsDropDownList(_context, movieToUpdate.ProductionID);
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

            _context.Attach(Movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(Movie.MovieID))
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
        /*
        private bool MovieExists(int id)
        {
          return _context.Movies.Any(e => e.MovieID == id);
        }
        */
    }
}

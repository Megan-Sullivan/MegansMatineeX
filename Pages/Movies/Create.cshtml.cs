using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegansMatineeX.Data;
using MegansMatineeX.Models;
using Microsoft.AspNetCore.Authorization;

namespace MegansMatineeX.Pages.Movies
{
    [AllowAnonymous]
    public class CreateModel : ProductionNamePageModel
    {
        private readonly MegansMatineeX.Data.MegansMatineeXContext _context;

        public CreateModel(MegansMatineeX.Data.MegansMatineeXContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateProductionsDropDownList(_context);
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyMovie = new Movie();

            if (await TryUpdateModelAsync<Movie>(
                 emptyMovie,
                 "movie",   // Prefix for form value.
                 s => s.MovieID, s => s.ProductionID, s => s.Title))
            {
                _context.Movies.Add(emptyMovie);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            // Select ProductionID if TryUpdateModelAsync fails.
            PopulateProductionsDropDownList(_context, emptyMovie.ProductionID);
            return Page();
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Movies.Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */
        }
    }
}

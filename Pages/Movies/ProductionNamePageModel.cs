using MegansMatineeX.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MegansMatineeX.Pages.Movies
{
    public class ProductionNamePageModel : PageModel
    {
        public SelectList ProductionNameSL { get; set; }

        public void PopulateProductionsDropDownList(MegansMatineeXContext _context,
            object selectedProduction = null)
        {
            var productionsQuery = from d in _context.Productions
                                   orderby d.Name // Sort by name.
                                   select d;

            ProductionNameSL = new SelectList(productionsQuery.AsNoTracking(),
                        "ProductionID", "Name", selectedProduction);
        }
    }
}

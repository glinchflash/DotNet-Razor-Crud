using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Champions.Model;

namespace RazorCrud.PageS_Champions
{
    public class DetailsModel : PageModel
    {
        private readonly RazorCrudChampionContext _context;

        public DetailsModel(RazorCrudChampionContext context)
        {
            _context = context;
        }

      public Champion Champion { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Champion == null)
            {
                return NotFound();
            }

            var champion = await _context.Champion.FirstOrDefaultAsync(m => m.ID == id);
            if (champion == null)
            {
                return NotFound();
            }
            else 
            {
                Champion = champion;
            }
            return Page();
        }
    }
}

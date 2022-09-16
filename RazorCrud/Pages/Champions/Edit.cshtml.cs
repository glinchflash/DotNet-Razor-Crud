using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Champions.Model;

namespace RazorCrud.PageS_Champions
{
    public class EditModel : PageModel
    {
        private readonly RazorCrudChampionContext _context;

        public EditModel(RazorCrudChampionContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Champion Champion { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Champion == null)
            {
                return NotFound();
            }

            var champion =  await _context.Champion.FirstOrDefaultAsync(m => m.ID == id);
            if (champion == null)
            {
                return NotFound();
            }
            Champion = champion;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Champion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionExists(Champion.ID))
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

        private bool ChampionExists(int id)
        {
          return (_context.Champion?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

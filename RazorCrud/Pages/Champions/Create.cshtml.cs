using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Champions.Model;

namespace RazorCrud.PageS_Champions
{
    public class CreateModel : PageModel
    {
        private readonly RazorCrudChampionContext _context;

        public CreateModel(RazorCrudChampionContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Champion Champion { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Champion == null || Champion == null)
            {
                return Page();
            }

            _context.Champion.Add(Champion);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

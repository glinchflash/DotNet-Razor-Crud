using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Summoners.Model;

namespace RazorCrud.Pages_Summonners
{
    public class CreateModel : PageModel
    {
        private readonly RazorCRUDSummonerContext _context;

        public CreateModel(RazorCRUDSummonerContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Summoner Summoner { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Summoner == null || Summoner == null)
            {
                return Page();
            }

            _context.Summoner.Add(Summoner);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Summoners.Model;

namespace RazorCrud.Pages_Summonners
{
    public class DeleteModel : PageModel
    {
        private readonly RazorCRUDSummonerContext _context;

        public DeleteModel(RazorCRUDSummonerContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Summoner Summoner { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Summoner == null)
            {
                return NotFound();
            }

            var summoner = await _context.Summoner.FirstOrDefaultAsync(m => m.ID == id);

            if (summoner == null)
            {
                return NotFound();
            }
            else 
            {
                Summoner = summoner;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Summoner == null)
            {
                return NotFound();
            }
            var summoner = await _context.Summoner.FindAsync(id);

            if (summoner != null)
            {
                Summoner = summoner;
                _context.Summoner.Remove(Summoner);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

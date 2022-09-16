using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Summoners.Model;

namespace RazorCrud.Pages_Summonners
{
    public class EditModel : PageModel
    {
        private readonly RazorCRUDSummonerContext _context;

        public EditModel(RazorCRUDSummonerContext context)
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

            var summoner =  await _context.Summoner.FirstOrDefaultAsync(m => m.ID == id);
            if (summoner == null)
            {
                return NotFound();
            }
            Summoner = summoner;
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

            _context.Attach(Summoner).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SummonerExists(Summoner.ID))
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

        private bool SummonerExists(int id)
        {
          return (_context.Summoner?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}

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
    public class DetailsModel : PageModel
    {
        private readonly RazorCRUDSummonerContext _context;

        public DetailsModel(RazorCRUDSummonerContext context)
        {
            _context = context;
        }

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
    }
}

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
    public class IndexModel : PageModel
    {
        private readonly RazorCRUDSummonerContext _context;

        public IndexModel(RazorCRUDSummonerContext context)
        {
            _context = context;
        }

        public IList<Summoner> Summoner { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Summoner != null)
            {
                Summoner = await _context.Summoner.ToListAsync();
            }
        }
    }
}

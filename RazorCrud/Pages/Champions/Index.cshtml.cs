using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Champions.Model;

namespace RazorCrud.Pages_Champions
{
    public class IndexModel : PageModel
    {
        private readonly RazorCrudChampionContext _context;

        public IndexModel(RazorCrudChampionContext context)
        {
            _context = context;
        }

        public IList<Champion> Champion { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Champion != null)
            {
                Champion = await _context.Champion.ToListAsync();
            }
        }
    }
}

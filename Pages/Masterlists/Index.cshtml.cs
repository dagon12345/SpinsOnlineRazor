using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models;

namespace SpinsOnlineRazor.Pages.Masterlists
{
    public class IndexModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SchoolContext _context;

        public IndexModel(SpinsOnlineRazor.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Masterlist> Masterlist { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Masterlist = await _context.Masterlist.ToListAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class IndexModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public IndexModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        public IList<Beneficiary> Beneficiary { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Beneficiary = await _context.Beneficiaries.ToListAsync();
        }
    }
}

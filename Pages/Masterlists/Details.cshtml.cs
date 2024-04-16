using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;

namespace SpinsOnlineRazor.Pages.Masterlists
{
    public class DetailsModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public DetailsModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        public Masterlist Masterlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterlist = await _context.Masterlists.FirstOrDefaultAsync(m => m.MasterlistID == id);
            if (masterlist == null)
            {
                return NotFound();
            }
            else
            {
                Masterlist = masterlist;
            }
            return Page();
        }
    }
}

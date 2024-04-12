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
    public class DeleteModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SchoolContext _context;

        public DeleteModel(SpinsOnlineRazor.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masterlist Masterlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterlist = await _context.Masterlist.FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterlist = await _context.Masterlist.FindAsync(id);
            if (masterlist != null)
            {
                Masterlist = masterlist;
                _context.Masterlist.Remove(Masterlist);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

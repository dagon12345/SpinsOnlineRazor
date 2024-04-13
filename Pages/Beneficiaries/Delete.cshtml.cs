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
    public class DeleteModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public DeleteModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficiary Beneficiary { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries.FirstOrDefaultAsync(m => m.ID == id);

            if (beneficiary == null)
            {
                return NotFound();
            }
            else
            {
                Beneficiary = beneficiary;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary != null)
            {
                Beneficiary = beneficiary;
                _context.Beneficiaries.Remove(Beneficiary);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

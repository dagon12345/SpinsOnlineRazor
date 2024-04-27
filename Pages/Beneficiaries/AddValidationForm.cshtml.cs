using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class AddValidationForm : PageModel
    {
        private readonly SpinsContext _context;

        public AddValidationForm(SpinsContext context)
        {
            _context = context;
        }
        public Beneficiary Beneficiary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
           if(id == null)
           {
            return NotFound();
           }
           Beneficiary = await _context.Beneficiaries
           .AsNoTracking()
           .Include(p => p.Validationform)
           .ThenInclude(p => p.Assessment)
           .FirstOrDefaultAsync(m => m.BeneficiaryID == id);

           if (Beneficiary == null)
            {
                return NotFound();
            }
           return Page();
        }
    }
}
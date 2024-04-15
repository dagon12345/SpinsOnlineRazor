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
    public class DetailsModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public DetailsModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        public Beneficiary Beneficiary { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            /*Beneficiary = await _context.Beneficiaries
            .Include(s => s.Masterlists)
            .ThenInclude(r => r.Region)
             .ThenInclude(p => p.Provinces)
              .ThenInclude(m => m.Municipalities)
               .ThenInclude(r => r.Barangays)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);*/

            //Code na mag pa show instead of Region, Province, Municipality, and Barangay codes and e show ila name an e show.
            Beneficiary = await _context.Beneficiaries
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Region)
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Province)
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Municipality)
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Barangay)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Sex)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Maritalstatus)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Validationform)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Validationform.Assessment)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.IdentificationType)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.BeneficiaryID == id);


            if (Beneficiary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

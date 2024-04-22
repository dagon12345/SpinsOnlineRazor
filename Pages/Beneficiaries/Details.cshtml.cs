using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class DetailsModel : PageModel
    {
        //private readonly IWebHostEnvironment _webHostEnvironment;
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


            //Code na mag pa show instead of Region, Province, Municipality, and Barangay codes and e show ila name an e show.
            Beneficiary = await _context.Beneficiaries
            // .Include(m => m.Region)
            // .Include(m => m.Province)
            // .Include(m => m.Municipality)
            // .Include(m => m.Barangay)
            // .Include(s => s.Validationform)
            // .ThenInclude(s => s.Assessment)
            // .Include(s => s.Sex)
            // .Include(s => s.Maritalstatus)
            // .Include(s => s.IdentificationType)
            // .Include(h => h.HealthStatus)// This entity is one is to one relation with Beneficiar
        .AsNoTracking()
        .Include(b => b.HealthStatus)
        .Include(b => b.IdentificationType)
        .Include(r => r.Region)
        .Include(p => p.Province)
        .Include(p => p.Municipality)
        .Include(p => p.Barangay)
        .Include(p => p.Sex)
        .Include(p => p.Maritalstatus)
        .Include(p => p.Status)
        .FirstOrDefaultAsync(m => m.BeneficiaryID == id);


            if (Beneficiary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

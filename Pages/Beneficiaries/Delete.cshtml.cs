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
        /*Adds Logging.
Adds the optional parameter saveChangesError to the OnGetAsync method signature. 
saveChangesError indicates whether the method was 
called after a failure to delete the student object.*/
        private readonly SpinsContext _context;
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(SpinsContext context,
                           ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
        public Beneficiary Beneficiary { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beneficiary = await _context.Beneficiaries
            .AsNoTracking()
            .Include(c => c.HealthStatus)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (beneficiary == null)
            {
                return NotFound();
            }
            try
            {
                _context.Beneficiaries.Remove(beneficiary);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Beneficiaries/Index");
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);

                return RedirectToAction("/Beneficiaries/Delete", new { id, saveChangesError = true });
            }
            /*The delete operation might fail because of transient network problems. 
            Transient network errors are more likely when the database is in the cloud. 
            The saveChangesError parameter is false when the Delete page OnGetAsync is called from the UI.
             When OnGetAsync is called by OnPostAsync because the delete operation failed, the saveChangesError parameter is true.*/

        }
    }
}

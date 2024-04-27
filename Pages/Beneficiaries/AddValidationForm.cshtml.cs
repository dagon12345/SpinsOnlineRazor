using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class AddValidationForm : PageModel
    {
        private readonly SpinsContext _context;

        public AddValidationForm(SpinsContext context)
        {
            _context = context;
        }
       // public Beneficiary Beneficiary { get; set; }
         public Validationform Validationform { get; set; }

        public SelectList AssessmentSL { get; set; }
         private void PopulateDropDownLists()
        {
            AssessmentSL = new SelectList(_context.Assessments.OrderBy(h => h.Name), nameof(Assessment.AssessmentID), nameof(Assessment.Name));
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PopulateDropDownLists();
           if(id == null)
           {
            return NotFound();
           }
           Validationform = await _context.Validationforms
           .AsNoTracking()
           .Include(p => p.Beneficiary)
           .FirstOrDefaultAsync(m => m.BeneficiaryID == id);

           if (Validationform == null)
            {
                return NotFound();
            }
           return Page();
        }
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var validationFormToUpdate = await _context.Validationforms
            .Include(p => p.Beneficiary)
            .FirstOrDefaultAsync(m => m.BeneficiaryID == id);
            if(validationFormToUpdate == null)
            {
                return NotFound();
            }
            if(await TryUpdateModelAsync<Validationform>(
                validationFormToUpdate,
                "validationform",
                i => i.AssessmentID, i => i.Indigenous, i => i.Pantawid, i => i.Beneficiary
            ))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
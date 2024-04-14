using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class EditModel : PageModel
    {
        private readonly SpinsContext _context;

        public EditModel(SpinsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Beneficiary Beneficiary { get; set; } = default!;

        /*FirstOrDefaultAsync has been replaced with FindAsync. 
        When you don't have to include related data, FindAsync is more efficient.
        OnPostAsync has an id parameter.
        The current student is fetched from the database, rather than creating an empty student.*/
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (Beneficiary == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var beneficiaryToUpdate = await _context.Beneficiaries.FindAsync(id);
            if (beneficiaryToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Beneficiary>(beneficiaryToUpdate, "beneficiary",
            s => s.LastName, s => s.FirstName, s => s.MiddleName, s => s.ExtName,s=>s.BirthDate))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool BeneficiaryExists(int id)
        {
            return _context.Beneficiaries.Any(e => e.BeneficiaryID == id);
        }
    }
}

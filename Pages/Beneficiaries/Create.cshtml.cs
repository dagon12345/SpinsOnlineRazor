using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class CreateModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public CreateModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Beneficiary Beneficiary { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beneficiaries.Add(Beneficiary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */


            /*Uses the posted form values from the PageContext property in the PageModel.
                Updates only the properties listed (s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate).
                Looks for form fields with a "student" prefix.
                For example, Student.FirstMidName. It's not case sensitive.
                Uses the model binding system to convert form values from strings to the types in the Student model. 
                For example, EnrollmentDate is converted to DateTime.*/
                
            //Code below disables the overposting, para sa mga hackers maka set sila nan data like bisan not eligible e eligible
            var emptyBeneficiary = new Beneficiary();

            if (await TryUpdateModelAsync<Beneficiary>(emptyBeneficiary, "beneficiary", s => s.LastName, s => s.FirstName,
             s => s.MiddleName, s => s.ExtName, s => s.BirthDate, s => s.IdentificationNumber))
            {
                _context.Beneficiaries.Add(emptyBeneficiary);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}

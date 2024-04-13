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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beneficiaries.Add(Beneficiary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;

namespace SpinsOnlineRazor.Pages.Masterlists
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
        ViewData["BarangayID"] = new SelectList(_context.Barangays, "BarangayID", "BarangayID");
        ViewData["BeneficiaryID"] = new SelectList(_context.Beneficiaries, "BeneficiaryID", "FirstName");
        ViewData["IdentificationTypeID"] = new SelectList(_context.IdentificationTypes, "IdentificationTypeID", "IdentificationTypeID");
        ViewData["MaritalstatusID"] = new SelectList(_context.MaritalStatuses, "MaritalstatusID", "MaritalstatusID");
        ViewData["MunicipalityID"] = new SelectList(_context.Municipalities, "MunicipalityID", "MunicipalityID");
        ViewData["ProvinceID"] = new SelectList(_context.Provinces, "ProvinceID", "ProvinceID");
        ViewData["RegionID"] = new SelectList(_context.Regions, "RegionID", "RegionID");
        ViewData["SexID"] = new SelectList(_context.Sexes, "SexID", "SexID");
        ViewData["StatusID"] = new SelectList(_context.Statuses, "StatusID", "StatusID");
        ViewData["ValidationformID"] = new SelectList(_context.Validationforms, "ValidationformID", "ValidationformID");
            return Page();
        }

        [BindProperty]
        public Masterlist Masterlist { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Masterlists.Add(Masterlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

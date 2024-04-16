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

namespace SpinsOnlineRazor.Pages.Masterlists
{
    public class EditModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public EditModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masterlist Masterlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterlist =  await _context.Masterlists.FirstOrDefaultAsync(m => m.MasterlistID == id);
            if (masterlist == null)
            {
                return NotFound();
            }
            Masterlist = masterlist;
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Masterlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterlistExists(Masterlist.MasterlistID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasterlistExists(int id)
        {
            return _context.Masterlists.Any(e => e.MasterlistID == id);
        }
    }
}

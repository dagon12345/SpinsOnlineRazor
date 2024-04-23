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
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;
using SpinsOnlineRazor.Models.RedesignModels.Dropdowns;

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
        public Beneficiary Beneficiary { get; set; }
        [BindProperty]
        public Validationform ValidationForm { get; set; }

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

            Beneficiary = await _context.Beneficiaries
            .Include(b => b.HealthStatus)
            .Include(i => i.IdentificationType)
            .Include(r => r.Region)
            .Include(p => p.Province)
            .Include(p => p.Municipality)
            .Include(p => p.Barangay)
            .Include(p => p.Sex)
            .Include(p => p.Maritalstatus)
            .Include(p => p.Status)
            .Include(p => p.Validationform)
            .FirstOrDefaultAsync(m => m.BeneficiaryID == id);


            // Beneficiary = await _context.Beneficiaries.FindAsync(id);
            if (Beneficiary == null)
            {
                return NotFound();
            }
            //Select current HealthStatusID
            // PopulateHealthStatusDropDownList(_context, Beneficiary.HealthStatusID);
            // PopulateIDDropDownList(_context, Beneficiary.IdentificationTypeID);
            // PopulateRegionDropDownList(_context, Beneficiary.RegionID);
            // PopulateProvinceDropDownList(_context, Beneficiary.ProvinceID);
            // PopulateMunicipalityDropDownList(_context, Beneficiary.MunicipalityID);
            // PopulateBarangayDropDownList(_context, Beneficiary.BarangayID);
            PopulateDropDownLists();
            return Page();
        }


        public SelectList HealthStatusSL { get; set; }
        public SelectList IdentificationTypeSL { get; set; }
        public SelectList RegionSL { get; set; }
        public SelectList ProvinceSL { get; set; }
        public SelectList MunicipalitySL { get; set; }
        public SelectList BarangaySL { get; set; }
        public SelectList SexSL { get; set; }
        public SelectList MaritalstatusSL { get; set; }
        public SelectList StatusSL { get; set; }

        private void PopulateDropDownLists()
        {
            HealthStatusSL = new SelectList(_context.HealthStatuses.OrderBy(h => h.Name), nameof(HealthStatus.HealthStatusID), nameof(HealthStatus.Name));
            IdentificationTypeSL = new SelectList(_context.IdentificationTypes.OrderBy(i => i.Name), nameof(IdentificationType.IdentificationTypeID), nameof(IdentificationType.Name));
            RegionSL = new SelectList(_context.Regions.OrderBy(r => r.Name), nameof(Region.RegionID), nameof(Region.Name));
            ProvinceSL = new SelectList(_context.Provinces.OrderBy(r => r.Name), nameof(Province.ProvinceID), nameof(Province.Name));
            MunicipalitySL = new SelectList(_context.Municipalities.OrderBy(r => r.Name), nameof(Municipality.MunicipalityID), nameof(Municipality.Name));
            BarangaySL = new SelectList(_context.Barangays.OrderBy(r => r.Name), nameof(Barangay.BarangayID), nameof(Barangay.Name));
            SexSL = new SelectList(_context.Sexes.OrderBy(r => r.Name), nameof(Sex.SexID), nameof(Sex.Name));
            MaritalstatusSL = new SelectList(_context.Maritalstatuses.OrderBy(r => r.Name), nameof(Maritalstatus.MaritalstatusID), nameof(Maritalstatus.Name));
            StatusSL = new SelectList(_context.Statuses.OrderBy(r => r.Name), nameof(Status.StatusID), nameof(Status.Name));
        }

        // Cascading the dropdown regions on code below.

        public async Task<JsonResult> OnGetProvincesAsync(int regionId)
        {
            var provinces = await _context.Provinces
                .Where(p => p.RegionID == regionId)
                .OrderBy(p => p.Name)
                .Select(p => new { p.ProvinceID, p.Name })
                .ToListAsync();

            return new JsonResult(provinces);
        }

        public async Task<JsonResult> OnGetMunicipalitiesAsync(int provinceId)
        {
            var municipalities = await _context.Municipalities
                .Where(m => m.ProvinceID == provinceId)
                .OrderBy(m => m.Name)
                .Select(m => new { m.MunicipalityID, m.Name })
                .ToListAsync();

            return new JsonResult(municipalities);
        }

        public async Task<JsonResult> OnGetBarangaysAsync(int municipalityId)
        {
            var barangays = await _context.Barangays
                .Where(b => b.MunicipalityID == municipalityId)
                .OrderBy(b => b.Name)
                .Select(b => new { b.BarangayID, b.Name })
                .ToListAsync();

            return new JsonResult(barangays);
        }



        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var beneficaryToUpdate = await _context.Beneficiaries.FindAsync(id);
            if (beneficaryToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Beneficiary>(
                beneficaryToUpdate,
                "beneficiary", // Prefix for form value
             s => s.HealthStatusID, s => s.IdentificationTypeID, s => s.RegionID, s => s.ProvinceID, s => s.MunicipalityID, s => s.BarangayID,
             s => s.LastName, s => s.FirstName, s => s.MiddleName, s => s.ExtName, s => s.BirthDate, s => s.IdentificationNumber, s => s.SexID,
             s => s.MaritalstatusID, s => s.StatusID,
             s => s.IdentificationDateIssued, s => s.SpecificAddress, s => s.ContactNumber, s => s.HealthRemarks
            ))

            {
                //beneficaryToUpdate.ValidationformID = beneficaryToUpdate.BeneficiaryID; // Update Beneficiary validation form ID same with existed Validation form
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            //Addin of validation form

            // var emptyValidationForm = new Validationform();

            // if (await TryUpdateModelAsync<Validationform>(emptyValidationForm, "Validationform",
            //  s => s.ValidationformID, s => s.AssessmentID, s => s.ReferenceCode, s => s.SpinsBatch, s => s.Pantawid, s => s.Indigenous
            //  ))
            // {
            //     // Set StatusID to 99 if it's not already set
            //     emptyValidationForm.ValidationformID = Beneficiary.BeneficiaryID; // Add validation form ID same with existed Beneficary form
            //     // Generate a reference code consisting of year, month, day, and a random number
            //     int referenceCode =
            //         (DateTime.Now.Year % 100) * 1_000_000 +    // Year (last two digits) shifted left by 6 digits
            //         DateTime.Now.Month * 10_000 +               // Month shifted left by 4 digits
            //         DateTime.Now.Day * 100 +                    // Day shifted left by 2 digits
            //         new Random().Next(100);                     // Random number (2 digits)

            //     // Assign the reference code to your property (assuming emptyValidationForm is an instance of your model)
            //     emptyValidationForm.ReferenceCode = referenceCode;



            //     _context.Validationforms.Add(emptyValidationForm);
            //     await _context.SaveChangesAsync();
            //     return RedirectToPage("./Index");
            // }
            // PopulateHealthStatusDropDownList(_context, beneficaryToUpdate.HealthStatusID);
            // PopulateIDDropDownList(_context, beneficaryToUpdate.IdentificationTypeID);
            // PopulateRegionDropDownList(_context, beneficaryToUpdate.RegionID);
            // PopulateProvinceDropDownList(_context, beneficaryToUpdate.ProvinceID);
            // PopulateMunicipalityDropDownList(_context, beneficaryToUpdate.MunicipalityID);
            // PopulateBarangayDropDownList(_context, beneficaryToUpdate.BarangayID);
            return Page();
        }

        
    }
}

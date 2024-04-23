using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;
using SpinsOnlineRazor.Models.RedesignModels.Dropdowns;
using Syncfusion.EJ2.Charts;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class CreateModel : PageModel
    {
        private readonly Data.SpinsContext _context;

        public CreateModel(Data.SpinsContext context)
        {
            _context = context;
        }

        public SelectList HealthStatusSL { get; set; }
        public SelectList IdentificationTypeSL { get; set; }
        public SelectList RegionSL { get; set; }
        public SelectList ProvinceSL { get; set; }
        public SelectList MunicipalitySL { get; set; }
        public SelectList BarangaySL { get; set; }
        public SelectList SexSL { get; set; }
        public SelectList MaritalStatusSL { get; set; }
        public SelectList StatusSL { get; set; }


        public IActionResult OnGet()
        {

            //Populate HealthStatus, IdentificationType
            // PopulateHealthStatusDropDownList(_context);
            // PopulateIDDropDownList(_context);
            // PopulateRegionDropDownList(_context);
            // PopulateProvinceDropDownList(_context);
            // PopulateMunicipalityDropDownList(_context);
            // PopulateBarangayDropDownList(_context);
            PopulateDropDownLists();
            return Page();

        }

        private void PopulateDropDownLists()
        {
            HealthStatusSL = new SelectList(_context.HealthStatuses.OrderBy(h => h.Name), nameof(HealthStatus.HealthStatusID), nameof(HealthStatus.Name));
            IdentificationTypeSL = new SelectList(_context.IdentificationTypes.OrderBy(i => i.Name), nameof(IdentificationType.IdentificationTypeID), nameof(IdentificationType.Name));
            RegionSL = new SelectList(_context.Regions.OrderBy(r => r.Name), nameof(Region.RegionID), nameof(Region.Name));
            ProvinceSL = new SelectList(new List<Province>(), nameof(Province.ProvinceID), nameof(Province.Name));
            MunicipalitySL = new SelectList(new List<Municipality>(), nameof(Municipality.MunicipalityID), nameof(Municipality.Name));
            BarangaySL = new SelectList(new List<Barangay>(), nameof(Barangay.BarangayID), nameof(Barangay.Name));
            SexSL = new SelectList(_context.Sexes.OrderBy(r => r.Name), nameof(Sex.SexID), nameof(Sex.Name));
            MaritalStatusSL = new SelectList(_context.Maritalstatuses.OrderBy(r => r.Name), nameof(Maritalstatus.MaritalstatusID), nameof(Maritalstatus.Name));
            StatusSL = new SelectList(_context.Statuses.OrderBy(r => r.Name), nameof(Status.StatusID), nameof(Status.Name));
        }

        //Below are the code for Cascading.

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

        [BindProperty]
        public Beneficiary Beneficiary { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*Uses the posted form values from the PageContext property in the PageModel.
                Updates only the properties listed (s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate).
                Looks for form fields with a "student" prefix.
                For example, Student.FirstMidName. It's not case sensitive.
                Uses the model binding system to convert form values from strings to the types in the Student model. 
                For example, EnrollmentDate is converted to DateTime.*/

            //Code below disables the overposting, para sa mga hackers maka set sila nan data like bisan not eligible e eligible
            var emptyBeneficiary = new Beneficiary();

            // if (await TryUpdateModelAsync<Beneficiary>(emptyBeneficiary, "Beneficiary", s => s.RegionID,s => s.ProvinceID,s => s.MunicipalityID,s => s.BarangayID, 
            //  s => s.SexID,s => s.MaritalstatusID,s => s.ValidationformID, s => s.StatusID,s => s.IdentificationTypeID,
            //  s => s.LastName, s => s.FirstName,
            //  s => s.MiddleName, s => s.ExtName, s => s.BirthDate, s => s.IdentificationNumber,
            //  s => s.IdentificationDateIssued, s => s.SpecificAddress, s => s.ContactNumber, s => s.HealthStatusID, s => s.HealthRemarks
            //  ))
            if (await TryUpdateModelAsync<Beneficiary>(emptyBeneficiary, "Beneficiary",
             s => s.HealthStatusID, s => s.IdentificationTypeID, s => s.RegionID, s => s.ProvinceID, s => s.MunicipalityID, s => s.BarangayID,
             s => s.SexID, s => s.MaritalstatusID,
             s => s.LastName, s => s.FirstName, s => s.MiddleName, s => s.ExtName, s => s.BirthDate, s => s.IdentificationNumber,
             s => s.IdentificationDateIssued, s => s.SpecificAddress, s => s.ContactNumber, s => s.HealthRemarks
             ))
            {
                // Set StatusID to 99 if it's not already set
                emptyBeneficiary.StatusID = 99;

                _context.Beneficiaries.Add(emptyBeneficiary);
                await _context.SaveChangesAsync();
                return RedirectToPage("/Beneficiaries/Index");
            }
            // PopulateHealthStatusDropDownList(_context, emptyBeneficiary.HealthStatusID);
            // PopulateHealthStatusDropDownList(_context, emptyBeneficiary.IdentificationTypeID);
            // PopulateRegionDropDownList(_context, emptyBeneficiary.RegionID);
            // PopulateProvinceDropDownList(_context, emptyBeneficiary.ProvinceID);
            // PopulateMunicipalityDropDownList(_context, emptyBeneficiary.MunicipalityID);
            // PopulateBarangayDropDownList(_context, emptyBeneficiary.BarangayID);
            return Page();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpinsOnlineRazor.Areas.Identity.Data;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;
using SpinsOnlineRazor.Models.RedesignModels.Dropdowns;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class EditModel : PageModel
    {
        private readonly UserManager<SpinsUser> _userManager;
        private readonly SignInManager<SpinsUser> _signInManager;
        private readonly SpinsContext _context;

        public EditModel(SpinsContext context, UserManager<SpinsUser> userManager,
            SignInManager<SpinsUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [BindProperty]
        public Beneficiary Beneficiary { get; set; }
        [BindProperty]
        public Validationform ValidationForm { get; set; }

        public IList<ViewModelLog> LogViewModel { get; set; }


        /*FirstOrDefaultAsync has been replaced with FindAsync. 
        When you don't have to include related data, FindAsync is more efficient.
        OnPostAsync has an id parameter.
        The current student is fetched from the database, rather than creating an empty student.*/
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            //var user = await _userManager.GetUserAsync(User);
            // if (user == null)
            // {
            //     return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            // }

            //await LoadAsync(user);

            IQueryable<Log> LogsIQ = _context.Logs;

            if (id == null)
            {
                return NotFound();
            }

            LogViewModel = await LogsIQ
           .Where(p => p.BeneficiaryID == id)
           .OrderByDescending(p => p.DateTimeEntry) // Order by DateTime in descending order
           .Select(p => new ViewModelLog
           {
               BeneficiaryID = p.BeneficiaryID,
               Message = p.Message,
               LogType = p.LogType,
               User = p.User,
               DateTimeEntry = p.DateTimeEntry
           })
          // .AsNoTracking()
          .ToListAsync();
            //.FirstOrDefaultAsync();
            //.FirstAsync(id);

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
            .Include(p => p.Logs)
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

            return new
             JsonResult(barangays);
        }


        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.

        public async Task<string> GetHealthStatusName(int healthstatusId)
        {
            var healthStatus = await _context.HealthStatuses.FindAsync(healthstatusId);
            return healthStatus?.Name;
        }
        public async Task<string> GetRegionName(int regionId)
        {
            var region = await _context.Regions.FindAsync(regionId);
            return region?.Name;
        }

        public async Task<string> GetProvinceName(int provinceId)
        {
            var province = await _context.Provinces.FindAsync(provinceId);
            return province?.Name;
        }
        public async Task<string> GetMunicipalityName(int municipalityId)
        {
            var municipality = await _context.Municipalities.FindAsync(municipalityId);
            return municipality?.Name;
        }
        public async Task<string> GetBarangayName(int barangayId)
        {
            var barangay = await _context.Barangays.FindAsync(barangayId);
            return barangay?.Name;
        }
        public async Task<string> IdentificationtypeName(int identificationId)
        {
            var identification = await _context.IdentificationTypes.FindAsync(identificationId);
            return identification?.Name;
        }

        public async Task<string> GetSexName(int SexId)
        {
            var sex = await _context.Sexes.FindAsync(SexId);
            return sex?.Name;
        }
        public async Task<string> GetMaritalName(int maritalstatusId)
        {
            var maritalstatus = await _context.Maritalstatuses.FindAsync(maritalstatusId);
            return maritalstatus?.Name;
        }
        public async Task<string> GetStatusName(int statusId)
        {
            var status = await _context.Statuses.FindAsync(statusId);
            return status?.Name;
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {
             var user = await _userManager.GetUserAsync(User);

            if (id == null)
            {
                return NotFound();
            }

            var beneficiaryToUpdate = await _context.Beneficiaries.FindAsync(id);
            if (beneficiaryToUpdate == null)
            {
                return NotFound();
            }

            // Clone the original beneficiary object to track changes
            var originalBeneficiary = JsonConvert.DeserializeObject<Beneficiary>(JsonConvert.SerializeObject(beneficiaryToUpdate));

            if (await TryUpdateModelAsync<Beneficiary>(
                beneficiaryToUpdate,
                "beneficiary", // Prefix for form value
                s => s.HealthStatusID, s => s.IdentificationTypeID, s => s.RegionID, s => s.ProvinceID, s => s.MunicipalityID, s => s.BarangayID,
                s => s.LastName, s => s.FirstName, s => s.MiddleName, s => s.ExtName, s => s.BirthDate, s => s.IdentificationNumber, s => s.SexID,
                s => s.MaritalstatusID, s => s.StatusID,
                s => s.IdentificationDateIssued, s => s.SpecificAddress, s => s.ContactNumber, s => s.HealthRemarks
            ))
            {
                // Compare original and updated beneficiary objects to detect changes
                var changes = new List<string>();
                // Compare specific properties for changes
                if (originalBeneficiary.LastName != beneficiaryToUpdate.LastName)
                {
                    changes.Add($"Last Name: {originalBeneficiary.LastName} => {beneficiaryToUpdate.LastName}");
                }
                if (originalBeneficiary.FirstName != beneficiaryToUpdate.FirstName)
                {
                    changes.Add($"First Name: {originalBeneficiary.FirstName} => {beneficiaryToUpdate.FirstName}");
                }

                if (originalBeneficiary.MiddleName != beneficiaryToUpdate.MiddleName)
                {
                    changes.Add($"Middle Name: {originalBeneficiary.MiddleName} => {beneficiaryToUpdate.MiddleName}");
                }

                if (originalBeneficiary.ExtName != beneficiaryToUpdate.ExtName)
                {
                    changes.Add($"Ext Name: {originalBeneficiary.ExtName} => {beneficiaryToUpdate.ExtName}");
                }
                if (originalBeneficiary.BirthDate != beneficiaryToUpdate.BirthDate)
                {
                    changes.Add($"Birth Date: {originalBeneficiary.BirthDate} => {beneficiaryToUpdate.BirthDate}");
                }

                if (originalBeneficiary.IdentificationNumber != beneficiaryToUpdate.IdentificationNumber)
                {
                    changes.Add($"Id Number: {originalBeneficiary.IdentificationNumber} => {beneficiaryToUpdate.IdentificationNumber}");
                }

                if (originalBeneficiary.IdentificationDateIssued != beneficiaryToUpdate.IdentificationDateIssued)
                {
                    changes.Add($"Id Issued Date: {originalBeneficiary.IdentificationDateIssued} => {beneficiaryToUpdate.IdentificationDateIssued}");
                }

                if (originalBeneficiary.SpecificAddress != beneficiaryToUpdate.SpecificAddress)
                {
                    changes.Add($"Address: {originalBeneficiary.SpecificAddress} => {beneficiaryToUpdate.SpecificAddress}");
                }

                if (originalBeneficiary.ContactNumber != beneficiaryToUpdate.ContactNumber)
                {
                    changes.Add($"Contact Number: {originalBeneficiary.ContactNumber} => {beneficiaryToUpdate.ContactNumber}");
                }
                if (originalBeneficiary.HealthRemarks != beneficiaryToUpdate.HealthRemarks)
                {
                    changes.Add($"Health Remarks: {originalBeneficiary.HealthRemarks} => {beneficiaryToUpdate.HealthRemarks}");
                }

                //Below are the FK with names
                if (originalBeneficiary.IdentificationTypeID != beneficiaryToUpdate.IdentificationTypeID)
                {
                    var originalIdName = await IdentificationtypeName(originalBeneficiary.IdentificationTypeID);
                    var updatedIdName = await IdentificationtypeName(beneficiaryToUpdate.IdentificationTypeID);
                    changes.Add($"Id type: {originalIdName} => {updatedIdName}");
                }

                if (originalBeneficiary.HealthStatusID != beneficiaryToUpdate.HealthStatusID)
                {
                    var originalHealthStatusName = await GetHealthStatusName(originalBeneficiary.HealthStatusID);
                    var updatedHealthStatusName = await GetHealthStatusName(beneficiaryToUpdate.HealthStatusID);
                    changes.Add($"HealthStatus: {originalHealthStatusName} => {updatedHealthStatusName}");
                }

                if (originalBeneficiary.ProvinceID != beneficiaryToUpdate.ProvinceID)
                {
                    var originalProvinceName = await GetProvinceName(originalBeneficiary.ProvinceID);
                    var updatedProvinceName = await GetProvinceName(beneficiaryToUpdate.ProvinceID);
                    changes.Add($"Province: {originalProvinceName} => {updatedProvinceName}");
                }

                if (originalBeneficiary.MunicipalityID != beneficiaryToUpdate.MunicipalityID)
                {
                    var originalMunicipalityName = await GetMunicipalityName(originalBeneficiary.MunicipalityID);
                    var updatedMunicipalityName = await GetMunicipalityName(beneficiaryToUpdate.MunicipalityID);
                    changes.Add($"Municipality: {originalMunicipalityName} => {updatedMunicipalityName}");
                }

                if (originalBeneficiary.BarangayID != beneficiaryToUpdate.BarangayID)
                {
                    var originalBarangayName = await GetBarangayName(originalBeneficiary.BarangayID);
                    var updatedBarangayName = await GetBarangayName(beneficiaryToUpdate.BarangayID);
                    changes.Add($"Barangay: {originalBarangayName} => {updatedBarangayName}");
                }

                if (originalBeneficiary.SexID != beneficiaryToUpdate.SexID)
                {
                    var originalSexName = await GetSexName(originalBeneficiary.SexID);
                    var updatedSexName = await GetSexName(beneficiaryToUpdate.SexID);
                    changes.Add($"Sex: {originalSexName} => {updatedSexName}");
                }

                if (originalBeneficiary.MaritalstatusID != beneficiaryToUpdate.MaritalstatusID)
                {
                    var originalMaritalName = await GetMaritalName(originalBeneficiary.MaritalstatusID);
                    var updatedMaritalName = await GetMaritalName(beneficiaryToUpdate.MaritalstatusID);
                    changes.Add($"Marital Status: {originalMaritalName} => {updatedMaritalName}");
                }

                if (originalBeneficiary.StatusID != beneficiaryToUpdate.StatusID)
                {
                    var originalStatusName = await GetStatusName(originalBeneficiary.StatusID);
                    var updatedStatusName = await GetStatusName(beneficiaryToUpdate.StatusID);
                    changes.Add($"Status: {originalStatusName} => {updatedStatusName}");
                }


                if (changes.Any())
                {
                    // Create a new Log entity
                    var log = new Log
                    {
                        BeneficiaryID = beneficiaryToUpdate.BeneficiaryID,
                        // Message = $"Beneficiary details updated. Changes: {string.Join(", ", changes)}",
                        Message = $"{string.Join(", ", changes)}",
                        LogType = 0, // Assuming 1 represents an update
                        User = $"{user.FirstName} {user.LastName}", // Set the user who made the changes
                        DateTimeEntry = DateTime.Now // Set the current date and time
                    };

                    // Add the Log entity to the DbContext
                    _context.Logs.Add(log);
                }

                await _context.SaveChangesAsync();
                return RedirectToPage("/Beneficiaries/Index");
            }

            return Page();
        }

    }
}

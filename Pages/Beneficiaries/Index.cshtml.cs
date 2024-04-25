using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using Microsoft.AspNetCore.Mvc;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class IndexModel : PageModel
  {
    private readonly SpinsContext _context;
    private readonly IConfiguration Configuration;
    public IndexModel(SpinsContext context, IConfiguration configuration)
    {
      _context = context;
      Configuration = configuration;
    }
        //Sorting sa ubos.
    public string NameSort { get; set; }
    public string CurrentFilter { get; set; }
    public string CurrentSort { get; set; }
    [BindProperty]
    public Beneficiary Beneficiary { get; set; }



     public IList<Beneficiary> BeneficiaryViewModel2 { get; set; }
     [BindProperty]
    public SelectList StatusOptions { get; set; }

    [BindProperty(SupportsGet = true)]
    public int StatusFilter { get; set; }
    [BindProperty]
     public SelectList MunicipalityOptions { get; set; }

    [BindProperty(SupportsGet = true)]
    public int MunicipalityFilter { get; set; }


   public SelectList ProvinceOptions { get; set; }

    [BindProperty(SupportsGet = true)]
    public int ProvinceFilter { get; set; }

    public IList<ViewModelBeneficiary> BeneficiaryViewModel { get; set; }
    public List<SelectListItem> Municipalities { get; set; }
    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, List<int> searchStatus, List<int> searchMunicipality, List<int> searchProvince)
    {
      Municipalities = _context.Municipalities.Select(a =>
      new SelectListItem
      {
        Value = a.MunicipalityID.ToString(),
        Text = a.Name
      }).ToList();
      
      DateTime today = DateTime.Today;

      IQueryable<Beneficiary> beneficiariesIQ = _context.Beneficiaries;
      
      StatusOptions = new SelectList(_context.Statuses, nameof(Status.StatusID), nameof(Status.Name));
      List<int> StatusFilter = searchStatus;
      MunicipalityOptions = new SelectList(_context.Municipalities.OrderBy(x => x.Name), nameof(Municipality.MunicipalityID), nameof(Municipality.Name));
      List<int> MunicipalityFilter = searchMunicipality;

      ProvinceOptions = new SelectList(_context.Provinces, nameof(Municipality.ProvinceID), nameof(Municipality.Name));
      List<int> ProvinceFilter = searchProvince;


      if(searchStatus.Count == 0 && searchMunicipality.Count == 0)
      {
           
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
            Age = today.Year - p.BirthDate.Year - (today.Month < p.BirthDate.Month || (today.Month == p.BirthDate.Month && today.Day < p.BirthDate.Day) ? 1 : 0),
            IdentificationType = p.IdentificationType.Name,
            IdentificationNo = p.IdentificationNumber,
            IdentificationDateIssued = p.IdentificationDateIssued,
            Address = p.SpecificAddress,
            ContactNumber = p.ContactNumber,
            HealthStatus = p.HealthStatus.Name,
            Remarks = p.HealthRemarks,
            RegionName = p.Region.Name,
            ProvinceName = p.Province.Name,
            MunicipalityName = p.Municipality.Name,
            BarangayName = p.Barangay.Name,
            Sex = p.Sex.Name,
            MaritalStatus = p.Maritalstatus.Name,
            Status = p.Status.Name,
            Assessment = p.Validationform.Assessment.Name,
            Referencecode = p.Validationform.ReferenceCode,
            SpinsBatch = p.Validationform.SpinsBatch,
            Pantawid = p.Validationform.Pantawid,
            Indigenous = p.Validationform.Indigenous,

            StatusID = p.StatusID,
            MunicipalityID = p.MunicipalityID

          })
          .AsNoTracking()
          .ToListAsync();

        
      }
      else if(searchStatus.Count != 0 && searchMunicipality.Count == 0)
      {
          
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
              Age = today.Year - p.BirthDate.Year - (today.Month < p.BirthDate.Month || (today.Month == p.BirthDate.Month && today.Day < p.BirthDate.Day) ? 1 : 0),
            IdentificationType = p.IdentificationType.Name,
            IdentificationNo = p.IdentificationNumber,
            IdentificationDateIssued = p.IdentificationDateIssued,
            Address = p.SpecificAddress,
            ContactNumber = p.ContactNumber,
            HealthStatus = p.HealthStatus.Name,
            Remarks = p.HealthRemarks,
            RegionName = p.Region.Name,
            ProvinceName = p.Province.Name,
            MunicipalityName = p.Municipality.Name,
            BarangayName = p.Barangay.Name,
            Sex = p.Sex.Name,
            MaritalStatus = p.Maritalstatus.Name,
            Status = p.Status.Name,
            Assessment = p.Validationform.Assessment.Name,
            Referencecode = p.Validationform.ReferenceCode,
            SpinsBatch = p.Validationform.SpinsBatch,
            Pantawid = p.Validationform.Pantawid,
            Indigenous = p.Validationform.Indigenous,

            StatusID = p.StatusID,
            MunicipalityID = p.MunicipalityID

          })
          .AsNoTracking()
          .Where(x => searchStatus.Contains(x.StatusID))
          .ToListAsync();

      }
       else if(searchStatus.Count == 0 && searchMunicipality.Count != 0)
      {
          
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
              Age = today.Year - p.BirthDate.Year - (today.Month < p.BirthDate.Month || (today.Month == p.BirthDate.Month && today.Day < p.BirthDate.Day) ? 1 : 0),
            IdentificationType = p.IdentificationType.Name,
            IdentificationNo = p.IdentificationNumber,
            IdentificationDateIssued = p.IdentificationDateIssued,
            Address = p.SpecificAddress,
            ContactNumber = p.ContactNumber,
            HealthStatus = p.HealthStatus.Name,
            Remarks = p.HealthRemarks,
            RegionName = p.Region.Name,
            ProvinceName = p.Province.Name,
            MunicipalityName = p.Municipality.Name,
            BarangayName = p.Barangay.Name,
            Sex = p.Sex.Name,
            MaritalStatus = p.Maritalstatus.Name,
            Status = p.Status.Name,
            Assessment = p.Validationform.Assessment.Name,
            Referencecode = p.Validationform.ReferenceCode,
            SpinsBatch = p.Validationform.SpinsBatch,
            Pantawid = p.Validationform.Pantawid,
            Indigenous = p.Validationform.Indigenous,

            StatusID = p.StatusID,
            MunicipalityID = p.MunicipalityID

          })
          .AsNoTracking()
          .Where(x => searchMunicipality.Contains(x.MunicipalityID))
          .ToListAsync();

      }
      else{
       

        //Beneficarylist = await _context.Beneficiaries.ToListAsync();
          
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
              Age = today.Year - p.BirthDate.Year - (today.Month < p.BirthDate.Month || (today.Month == p.BirthDate.Month && today.Day < p.BirthDate.Day) ? 1 : 0),
            IdentificationType = p.IdentificationType.Name,
            IdentificationNo = p.IdentificationNumber,
            IdentificationDateIssued = p.IdentificationDateIssued,
            Address = p.SpecificAddress,
            ContactNumber = p.ContactNumber,
            HealthStatus = p.HealthStatus.Name,
            Remarks = p.HealthRemarks,
            RegionName = p.Region.Name,
            ProvinceName = p.Province.Name,
            MunicipalityName = p.Municipality.Name,
            BarangayName = p.Barangay.Name,
            Sex = p.Sex.Name,
            MaritalStatus = p.Maritalstatus.Name,
            Status = p.Status.Name,
            Assessment = p.Validationform.Assessment.Name,
            Referencecode = p.Validationform.ReferenceCode,
            SpinsBatch = p.Validationform.SpinsBatch,
            Pantawid = p.Validationform.Pantawid,
            Indigenous = p.Validationform.Indigenous,

            StatusID = p.StatusID,
            MunicipalityID = p.MunicipalityID

          })
          .AsNoTracking()
          .Where(x => searchStatus.Contains(x.StatusID) && searchMunicipality.Contains(x.MunicipalityID))
          .ToListAsync();
      }
      

    
          
    }


    
  }
}

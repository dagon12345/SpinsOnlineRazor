using System.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;
using Microsoft.AspNetCore.Mvc.Rendering;

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


    public IList<Beneficiary> Beneficarylist { get; set; }
     public IList<Beneficiary> BeneficiaryViewModel2 { get; set; }
    public SelectList StatusOptions { get; set; }
      [BindProperty(SupportsGet = true)]
    public int StatusFilter { get; set; }

     public SelectList MunicipalityOptions { get; set; }
       [BindProperty(SupportsGet = true)]
    public int MunicipalityFilter { get; set; }


   

    public List<ViewModelBeneficiary> BeneficiaryViewModel { get; set; }
    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex, List<int> searchStatus, List<int> searchMunicipality)
    {
      
   
      
      StatusOptions = new SelectList(_context.Statuses, nameof(Status.StatusID), nameof(Status.Name));
      List<int> StatusFilter = searchStatus;
      MunicipalityOptions = new SelectList(_context.Municipalities, nameof(Municipality.MunicipalityID), nameof(Municipality.Name));
      List<int> MunicipalityFilter = searchMunicipality;

      if(searchStatus.Count == 0 && searchMunicipality.Count == 0)
      {
              IQueryable<Beneficiary> beneficiariesIQ = _context.Beneficiaries;
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
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
             IQueryable<Beneficiary> beneficiariesIQ = _context.Beneficiaries;
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
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
             IQueryable<Beneficiary> beneficiariesIQ = _context.Beneficiaries;
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
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
          IQueryable<Beneficiary> beneficiariesIQ = _context.Beneficiaries;
          BeneficiaryViewModel = await  beneficiariesIQ
           .Select(p => new ViewModelBeneficiary
          {
            BeneficiaryID = p.BeneficiaryID,
            LastName = p.LastName,
            FirstName = p.FirstName,
            MiddleName = p.MiddleName,
            ExtName = p.ExtName,
            BirthDate = p.BirthDate,
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




        //  Beneficarylist = await _context.Beneficiaries
        //  .Where(x => searchStatus.Contains(x.StatusID) && searchMunicipality.Contains(x.MunicipalityID))
        //  .ToListAsync();
      }
      



      //StatusFilter = searchStatus;
      // IQueryable<Beneficiary> beneficiariesIQ = from s in _context.Beneficiaries select s;
        // .Include(r => r.HealthStatus)
        //         .Include(r => r.Region)
        //         .Include(r => r.Province)
        //         .Include(r => r.Municipality)
        //         .Include(r => r.Barangay)
        //         .Include(r => r.Sex)
        //         .Include(r => r.Maritalstatus)
        //         .Include(r => r.Status)
        //         .Include(r => r.IdentificationType)
        //         .Include(r => r.Validationform)
        //         .ThenInclude(r => r.Assessment)
                                              

      // if (!String.IsNullOrEmpty(searchString)) // Not null or empty because of !
      // {
      //   /*SQL Server defaults to case-insensitive. SQLite defaults to case-sensitive.Kung Sql server dili case sensitive
      //   Kung SQLite ato gamiton kay case sensitive need nat mag add nan .ToUpper()
      //   example nan ini kay ini:
      //   s.FirstName.Contains(searchString.ToUpper())
      //   Pero jauy performance penalty and .ToUpper().The ToUpper code adds a function in the WHERE clause of the TSQL SELECT statement. 
      //   The added function prevents the optimizer from using an index. 
      //   Given that SQL is installed as case-insensitive, it's best to avoid the ToUpper call when it's not needed*/
      //   beneficiariesIQ = beneficiariesIQ.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString)
      //   || s.MunicipalityID == int.Parse(searchString)
      //   || s.MiddleName.Contains(searchString) || s.LastName.Contains(searchString) && s.FirstName.Contains(searchString) && s.MiddleName.Contains(searchString));
      // }

      // switch (sortOrder)
      // {
      //   case "name_desc":
      //     beneficiariesIQ = beneficiariesIQ.OrderByDescending(s => s.LastName);
      //     break;
      //   default:
      //     beneficiariesIQ = beneficiariesIQ.OrderBy(s => s.LastName);
      //     break;

      // }
    
          
    }
    
  }
}

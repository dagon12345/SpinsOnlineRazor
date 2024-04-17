using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Pages.Masterlists
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
         public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<ViewModelBeneficiary> BeneficiaryViewModel { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
           var pageSize = Configuration.GetValue("PageSizeMasterlist", 11);
            IQueryable<Masterlist> beneficiariesIQ = _context.Masterlists
                .Include(r => r.Region)
                .Include(p => p.Province)
                .Include(m => m.Municipality)
                .Include(b => b.Barangay)
                .Include(s => s.Sex)
                .Include(m => m.Maritalstatus)
                .Include(v => v.Validationform)
                .ThenInclude(a => a.Assessment)
                .Include(s => s.Status)
                .Include(i => i.IdentificationType);

            BeneficiaryViewModel = await PaginatedList<ViewModelBeneficiary>.CreateAsync(
                beneficiariesIQ.Select(p => new ViewModelBeneficiary
                {
                    LastName = p.Beneficiary.LastName,
                    FirstName = p.Beneficiary.FirstName,
                    MiddleName = p.Beneficiary.MiddleName,
                    ExtName = p.Beneficiary.ExtName,
                    BirthDate = p.Beneficiary.BirthDate,
                    IdentificationNo = p.Beneficiary.IdentificationNumber,
                    IdentificationDate = p.Beneficiary.IdentificationDateIssued,
                    RegionName = p.Region.Name,
                    ProvinceName = p.Province.Name,
                    MunicipalityName = p.Municipality.Name,
                    BarangayName = p.Barangay.Name,
                    Sex = p.Sex.Name,
                    MaritalStatus = p.Maritalstatus.Name,
                    Assessment = p.Validationform.Assessment.Name,
                    Referencecode = p.Validationform.ReferenceCode,
                    SpinsBatch = p.Validationform.SpinsBatch,
                    Status = p.Status.Name,
                    IdentificationType = p.IdentificationType.Name,
                    Address = p.Beneficiary.SpecificAddress,
                    ContactNumber = p.Beneficiary.ContactNumber,
                    Pantawid = p.Validationform.Pantawid,
                    Indigenous = p.Validationform.Indigenous
                }).AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}

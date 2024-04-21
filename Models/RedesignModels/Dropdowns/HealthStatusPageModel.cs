using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;

namespace SpinsOnlineRazor.Models.RedesignModels.Dropdowns
{
    public class HealthStatusPageModel : PageModel
    {

        //Health Status dropdown here
        public SelectList HealthStatusSL { get; set; }

        public void PopulateHealthStatusDropDownList(SpinsContext _context,
            object selectHealthStatus = null)
        {
            var HealthstatusQuery = from d in _context.HealthStatuses
                                    orderby d.Name // Sort by name.
                                    select d;

            HealthStatusSL = new SelectList(HealthstatusQuery.AsNoTracking(),
                nameof(HealthStatus.HealthStatusID),
                nameof(HealthStatus.Name),
                selectHealthStatus);
        }
        //Identification Type dropdown here.
        public SelectList IdentificationTypeSL { get; set; }

        public void PopulateIDDropDownList(SpinsContext _context,
            object selectIDType = null)
        {
            var identificationTypeQuery = from d in _context.IdentificationTypes
                                          orderby d.Name // Sort by name.
                                          select d;

            IdentificationTypeSL = new SelectList(identificationTypeQuery.AsNoTracking(),
                nameof(IdentificationType.IdentificationTypeID),
                nameof(IdentificationType.Name),
                selectIDType);
        }

        //Region here dropdown
        public SelectList regionSL { get; set; }

        public void PopulateRegionDropDownList(SpinsContext _context,
           object selectRegion = null)
        {
            var regionQuery = from d in _context.Regions
                              orderby d.Name // Sort by name.
                              select d;

            regionSL = new SelectList(regionQuery.AsNoTracking(),
                nameof(Region.RegionID),
                nameof(Region.Name),
                selectRegion);
        }

        //Province dropdown here

        public SelectList provinceSL { get; set; }

        public void PopulateProvinceDropDownList(SpinsContext _context,
           object selectProvince = null)
        {
            var provinceQuery = from d in _context.Provinces
                                orderby d.Name // Sort by name.
                                select d;

            provinceSL = new SelectList(provinceQuery.AsNoTracking(),
                nameof(Province.ProvinceID),
                nameof(Province.Name),
                selectProvince);
        }

        //Municipality dropdown here

        public SelectList municipalitySL { get; set; }

        public void PopulateMunicipalityDropDownList(SpinsContext _context,
           object selectMunicipality = null)
        {
            var municipalityQuery = from d in _context.Municipalities
                                    orderby d.Name // Sort by name.
                                    select d;

            municipalitySL = new SelectList(municipalityQuery.AsNoTracking(),
                nameof(Municipality.MunicipalityID),
                nameof(Municipality.Name),
                selectMunicipality);
        }

        //Barangay dropdown here

        public SelectList barangaySL { get; set; }

        public void PopulateBarangayDropDownList(SpinsContext _context,
           object selectBarangay = null)
        {
            var barangayQuery = from d in _context.Barangays
                                orderby d.Name // Sort by name.
                                select d;

            barangaySL = new SelectList(barangayQuery.AsNoTracking(),
                nameof(Barangay.BarangayID),
                nameof(Municipality.Name),
                selectBarangay);
        }

    }
}
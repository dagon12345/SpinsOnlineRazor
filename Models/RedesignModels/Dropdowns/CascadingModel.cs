using Microsoft.AspNetCore.Mvc.Rendering;

namespace SpinsOnlineRazor.Models.RedesignModels.Dropdowns
{
    public class CascadingModel
    {
        public CascadingModel()
        {
            this.Regions = new List<SelectListItem>();
            this.Provinces = new List<SelectListItem>();
            this.Municipalities = new List<SelectListItem>();
            this.Barangays = new List<SelectListItem>();
        }
        public List<SelectListItem> Regions { get; set; }
        public List<SelectListItem> Provinces { get; set; }
        public List<SelectListItem> Municipalities { get; set; }
         public List<SelectListItem> Barangays { get; set; }

        public int RegionID { get; set; }
        public int ProvinceID { get; set; }
        public int MunicipalityID { get; set; }
        public int BarangayID { get; set; }
    }
}
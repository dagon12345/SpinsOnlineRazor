using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;

namespace SpinsOnlineRazor.Models
{
    public class LibraryBarangay
    {
        [Key]
        public int PSGCBrgy { get; set; }
        public string BrgyName { get; set; }

        public int PSGCCityMun { get; set; }
        public int ClassificationID { get; set; }

        public ICollection<Masterlistold> Masterlist { get; set; }

          /*The LibraryMunicipality property is defined as ICollection<LibraryMunicipality> 
        because there may be multiple related LibraryMunicipality entities*/

        // Isa rakaw ka municipalidad kay barangay raman kaw pinaka ubos
        public LibraryMunicipality LibraryMunicipalitys { get; set; }
    }
}
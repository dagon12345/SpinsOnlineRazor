using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models
{
    public class LibraryMunicipality
    {
        [Key]
        public int PSGCCityMun { get; set; }
        public string CityMunName { get; set; }

        public int PSGCProvince { get; set; }
        public int District { get; set; }

        public ICollection<Masterlistold> Masterlists { get; set; }

          //Isa ra ka province im gamiton if ikaw municipality fit rakaw sa isa ka probinsya
        public LibraryProvince LibraryProvinces { get; set; }

        //Dabo na barangay magamit sa imo

        public ICollection<LibraryBarangay> LibraryBarangays { get; set; }
    }
}
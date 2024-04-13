using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models
{
    public class LibraryProvince
    {
        [Key]
        public int PSGCProvince { get; set; }
        public string ProvinceName { get; set; }
        public int PSGCRegion { get; set; }

        public ICollection<Masterlistold> Masterlists { get; set; }

        //Isa ra ka region m gamiton sa isa ka province
        public LibraryRegion LibraryRegions { get; set; }

        //Dabo na municipalidad na mugamit sa m ugsa ICollection
        public ICollection<LibraryMunicipality> LibraryMunicipalitys { get; set; }
    }
}
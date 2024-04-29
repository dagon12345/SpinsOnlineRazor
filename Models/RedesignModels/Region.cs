using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Region
    {
        /*The DatabaseGenerated attribute allows the app to
         specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }
        public string Name { get; set; }

        
        //public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m
        public ICollection<Beneficiary> Beneficiaries { get; set; }
       // public ICollection<Province> Provinces { get; set; } // dabo na province mugamit sa region
    }
}
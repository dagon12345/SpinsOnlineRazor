using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Barangay
    {
         /*The DatabaseGenerated attribute allows the app to
         specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BarangayID { get; set; }
        public string Name { get; set; }

        // Cascade nato an municipality ID, kung ang user mag select nan barangay matic cascade from Barangay to Municipality to Province to Region.
        public int MunicipalityID { get; set; }

         //Mudawat sija na dabo na Masterlist gikan sa Beneficiary na mga data.So an masterlist kay collection
       // public ICollection<Masterlist> Masterlists { get; set; }

        //Dabo barangay sa isa ka municipality. An barangay kay isa ra ka municipality naka base so dili collection
        public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m


        
    }
}
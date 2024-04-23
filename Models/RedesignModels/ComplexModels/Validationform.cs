using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class Validationform
    {
        
        public int ValidationformID { get; set; }
        [ForeignKey("Beneficiary")]
        public int BeneficiaryID { get; set; }// The FK
        public int AssessmentID { get; set; }
        //public Assessment Assessment { get; set; }
        public int ReferenceCode { get; set; } // URL for PDF FIles
        public int? SpinsBatch { get; set; }
        public bool Pantawid { get; set; }
        public bool Indigenous { get; set; }

        public Beneficiary Beneficiary { get; set; } //One is to One relationship with Beneficiary
        public Assessment Assessment { get; set; }

    }
}
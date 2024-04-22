using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class Validationform
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ValidationformID { get; set; }
        public int AssessmentID { get; set; }
        //public Assessment Assessment { get; set; }
        public int ReferenceCode { get; set; } // URL for PDF FIles
        public int? SpinsBatch { get; set; }
        public bool Pantawid { get; set; }
        public bool Indigenous { get; set; }

        public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m
                                                                    // isa ra ka assessment kada validation

    }
}
namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class Validationform
    {
        public int ValidationformID { get; set; }
        public int ReferenceCode { get; set; }
        public int SpinsBatch { get; set; }
        public int AssessmentID { get; set; }
        
         //Collection kaw nan masterlist kay dabo mugamit sa m na masterlist pero isa ra m hatagan per bene
         public ICollection<Masterlist> Masterlists { get; set; }


            // isa ra ka assessment kada validation
         public Assessment Assessment { get; set; }
    }
}
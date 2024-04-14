using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class Validationform
    {
        public int ValidationformID { get; set; }
        public int AssessmentID { get; set; }
        public int ReferenceCode { get; set; }
        public int SpinsBatch { get; set; }
        
         //Collection kaw nan masterlist kay dabo mugamit sa m na masterlist pero isa ra m hatagan per bene
         public ICollection<Masterlist> Masterlists { get; set; }
    }
}
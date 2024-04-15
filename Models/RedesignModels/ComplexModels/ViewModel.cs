using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class ViewModel
    {
        public int BeneficiaryID { get; set; }
        public string LastName { get; set; }
        public string  FirstName { get; set; }  
        public string MiddleName { get; set; }
        public string ExtName { get; set; }
        public int AssessmentID { get; set; }
    }
}
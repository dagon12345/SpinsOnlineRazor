using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class ValidationForm
    {
        public int ValidationformID { get; set; }
        public int BeneficiaryID { get; set; }
        public int AssessmentID { get; set; } // Foreign key para sa Assessment Entity
        public int ReferenceCode { get; set; }
        public int SpinsBatch { get; set; }

        //One bene ra an hatagan dili pwedi mag dabo nan validation form an bene
        public Beneficiary Beneficiary { get; set; }
        //Isa ra ka assessment ija dawaton, di mag dabo kay di sija pwedi na eligible sanan not eligible mag sagol. So single dili collection
        public Assessment Assessment { get; set; }
    }
}
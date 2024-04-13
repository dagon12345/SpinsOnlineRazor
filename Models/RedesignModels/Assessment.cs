using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Assessment
    {
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AssessmentID { get; set; } // Primary Key ma mo connect sa Validation Form AssessmentID
        public string Name { get; set; }

        //Dabo ija hatagan na Validation form so ICollection and Validation form
        public ICollection<ValidationForm> ValidationForms { get; set; }
    }
}
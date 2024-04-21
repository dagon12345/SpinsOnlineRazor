using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusID { get; set; }
        public string Name { get; set; }
        //One is to one with masterlist
        
         public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m

}
}
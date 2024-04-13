using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Maritalstatus
    {
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaritalstatusID { get; set; }
        public string Name { get; set; }

        //Dabo an ma cater nan marital sa Masterlist so ICollection again an masterlist
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
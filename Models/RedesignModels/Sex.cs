using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Sex
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SexID { get; set; }
        public string Name { get; set; }

        //Dabo na masterlist an e cater nan sex so ICollection an Masterlist
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
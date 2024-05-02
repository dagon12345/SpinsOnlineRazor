using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Log
    {
        public int Id { get; set; }
        
        [ForeignKey("Beneficiary")]
        public int BenficiaryID { get; set; }
        public string Message { get; set; }
        public int LogType { get; set; }
        public string User { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Entry")]
        public DateTime DateTimeEntry { get; set; }

        
        // One Beneficiary
        public Beneficiary Beneficiary { get; set; }

    }
}
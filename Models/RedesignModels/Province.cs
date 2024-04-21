using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Province
    {
         /*The DatabaseGenerated attribute allows the app to
         specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProvinceID { get; set; }
        public string Name { get; set; }
        public int RegionID { get; set; }//Cascade ini sija from Entity Barangay nagsugod

       
        public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m


        //public ICollection<Municipality> Municipalities { get; set; } // Dabo na municipalities magamit sa region

        //Isa ra ka province an naka base sa isa ka Region so dili collection an region diri
        //public Region Region { get; set; } // Isa ra ka region an m mgamit
    }
}
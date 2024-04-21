using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Municipality
    {
         /*The DatabaseGenerated attribute allows the app to
         specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MunicipalityID { get; set; }
        public string Name { get; set; }
        public int ProvinceID { get; set; }// Naka Cascade sija sa province nag sugod sa pinaka ubos sa Barangay.

        //Mudawat sija na dabo na Masterlist gikan sa Beneficiary na mga data.So an masterlist kay collection

        //Dabo na Barangay an luon sa isa ka Municipality so collection sija nan barangay
         public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m
        
    }
}
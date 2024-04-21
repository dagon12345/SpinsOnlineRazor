using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class IdentificationType
    {
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int IdentificationTypeID { get; set; }
         public string Name { get; set; }

        //Dabo na masterlist mugamit sa m
         
         public ICollection<Beneficiary> Beneficiaries { get; set; } // Dabo na bene mugamit sa m

    }
}
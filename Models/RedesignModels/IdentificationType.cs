using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class IdentificationType
    {
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int IdentificationTypeID { get; set; }
         public string Name { get; set; }
         //public string Number { get; set; }

        //An IdentificationType kay Collection nan masterlist kay dabo magamit sa ija na masterlist
         public ICollection<Masterlist> Masterlists { get; set; }
    }
}
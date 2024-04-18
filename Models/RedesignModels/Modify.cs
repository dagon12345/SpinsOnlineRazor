using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Modify
    {
         [DatabaseGenerated(DatabaseGeneratedOption.None)]
         public int ModifyID { get; set; }
         public bool IsModified { get; set; }
         public string ModifiedBy { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Modified Date")]
         public DateTime ModifiedDate { get; set; }

         //Many detail model will use you so you are a collection
         public ICollection<Detail> Details { get; set; }                    
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Deceased
    {
       [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeceasedID { get; set; }
        public bool IsDeceased { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deceased Date")]
        public DateTime DeceasedDate { get; set; }

        //dabo na detail magamit sa m so collection an detail
        public ICollection<Detail> Details { get; set; }
    }
}
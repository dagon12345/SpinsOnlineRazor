using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Delete
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeleteID { get; set; }
        public bool IsDeleted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Deleted Date")]
        public DateTime DeletedDate { get; set; }

        //Dabo na detail mugamit sa m so collection
        public ICollection<Detail> Details { get; set; }
    }
}
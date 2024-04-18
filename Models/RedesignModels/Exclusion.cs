using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Exclusion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ExclusionID { get; set; }
        public bool IsExcluded { get; set; }
        public string ExclusionBatch { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Exclusion Date")]
        public DateTime ExclusionDate { get; set; }

        //Dabo na detail mugamit sa m
        public ICollection<Detail> Details { get; set; }
    }
}
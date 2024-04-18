using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Detail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DetailID { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Entered")]
        public DateTime DateEntered { get; set; }
        public string EnteredBy { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Inclusion Date")]
        public DateTime InclusionDate { get; set; }

        //Exclusion model
        public int? ExclusionID { get; set; }
        //Deceased model
        public int? DeceasedID { get; set; }
        //Modify model
        public int? ModifyID { get; set; }

        //Delete model
        public int? DeleteID { get; set; }

        public int WaitlistedID { get; set; }

        //Dabo na masterlist magamit sa m.
        public ICollection<Masterlist> Masterlists { get; set; }

        // Isa ra ka exclusion id per details of masterlist that based on bene
        public Exclusion Exclusion { get; set; }
        public Deceased Deceased { get; set; }
        public Modify Modify { get; set; }
        public Delete Delete { get; set; }

    }
}
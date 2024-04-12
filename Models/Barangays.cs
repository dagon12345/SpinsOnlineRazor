using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models
{
    public class Barangays
    {
         /*The DatabaseGenerated attribute allows the app to 
        specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PSGCBrgyID { get; set; }
        public string BrgyName { get; set; }
        public int PSGCCityMun { get; set; }
        public int ClassificationID { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }

    }
}
using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models
{
    public class Regions
    {
        /*The DatabaseGenerated attribute allows the app to 
        specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PSGCRegionID { get; set; }
        public string Region { get; set; }
        public int Default { get; set; }
        public int TenDigitCode { get; set; }
        public DateTime DateTimeEntry { get; set; }
        public DateTime DateTimeModified { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
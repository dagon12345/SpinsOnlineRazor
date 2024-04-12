using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models
{
    public class Provinces
    {
         /*The DatabaseGenerated attribute allows the app to 
        specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PSGCProvinceID { get; set; }
        public string ProvinceName { get; set; }
        public int PSGCRegion { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
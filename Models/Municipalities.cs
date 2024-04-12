using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models
{
    public class Municipalities
    {
         /*The DatabaseGenerated attribute allows the app to 
        specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PSGCCityMunID { get; set; }
        public string CityMunName { get; set; } 
        public int PSGCProvince { get; set; }
        public int District { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
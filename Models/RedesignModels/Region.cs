using System.ComponentModel.DataAnnotations.Schema;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Region
    {
        /*The DatabaseGenerated attribute allows the app to
         specify the primary key rather than having the database generate it.*/
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegionID { get; set; }
        public string Name { get; set; }

        //Mudawat sija na dabo na Masterlist gikan sa Beneficiary na mga data.So an masterlist kay collection
        public ICollection<Masterlist> Masterlists { get; set; }

        //Dabo na provinsya an sakop nan isa ka region so collection sija nan province
        public ICollection<Province> Provinces { get; set; }
    }
}
namespace SpinsOnlineRazor.Models
{
    public class Provinces
    {
        public int ID { get; set; }
        public int PSGCProvince { get; set; }
        public string ProvinceName { get; set; }
        public int PSGCRegion { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
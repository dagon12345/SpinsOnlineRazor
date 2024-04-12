namespace SpinsOnlineRazor.Models
{
    public class Barangays
    {
        public int ID { get; set; }
        public int PSGCBrgy { get; set; }
        public string BrgyName { get; set; }
        public int PSGCCityMun { get; set; }
        public int ClassificationID { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }

    }
}
namespace SpinsOnlineRazor.Models
{
    public class Municipalitys
    {
        public int ID { get; set; }
        public int PSGCCityMun { get; set; }
        public string CityMunName { get; set; } 
        public int PSGCProvince { get; set; }
        public int District { get; set; }

        /*The Masterlists property is defined as ICollection<Masterlist> 
        because there may be multiple related Masterlist entities*/
        public ICollection<Masterlist> Masterlists { get; set; }
    }
}
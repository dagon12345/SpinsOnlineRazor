namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Beneficiary
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string ExtName { get; set; }

        public DateTime BirthDate { get; set; }
        /*One is to Many relationship with Masterlist Entity, isa ra ka name sa Bene an makasuyod
         sa masterlist pero an masterlist mudawat nan dabo na beneficiary, try nat an ICollection*/
        public ICollection<Masterlist> Masterlists { get; set; }

        //Isa  ra ka validation form per bene. Pero an validation form dabo na bene an mahatagan one validation form many bene
        public ICollection<ValidationForm> ValidationForm { get; set; }
  
    }
}
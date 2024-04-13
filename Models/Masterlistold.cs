

namespace SpinsOnlineRazor.Models
{
    public class Masterlistold
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string  FirstName { get; set; }
        public string MiddleName { get; set; }
        public string ExtName { get; set; } 
        public string Citizenship { get; set; }
        public string MothersMaiden { get; set; }
        public int PSGCRegion { get; set; }
        public int PSGCProvince { get; set; }
        public int PSGCCityMun { get; set; }
        public int PSGCBrgy { get; set; }
        public string Address { get; set; }
        public DateTime BirthDate { get; set; }
        public int SexID { get; set; }
        public int MaritalStatusID { get; set; }
        public string Religion { get; set; }
        public string BirthPlace { get; set; }
        public string EducAttain { get; set; }
        public int IDTypeID { get; set; }
        public string IDNumber { get; set; }
        public DateTime IDDateIssued { get; set; }
        public int Pantawid { get; set; }
        public int Indigenous { get; set; } 
        public string SocialPensionID { get; set; }
        public string HouseholdID { get; set; }
        public string IndigenousID { get; set; }
        public string ContactNum { get; set; }
        public int HealthStatusID { get; set; }
        public string HealthStatusRemarks { get; set; } 
        public DateTime DateTimeEntry { get; set; }
        public string EntryBy { get; set; }
        public int DataSourceID { get; set; }
        public int StatusID { get; set; }
        public string Remarks { get; set; }
        public int RegTypeID { get; set; }
        public string InclusionBatch { get; set; }
        public DateTime InclusionDate { get; set; }
        public string ExclusionBatch { get; set; }
        public DateTime ExclusionDate { get; set; }
        public string DateDeceased { get; set; }
        public DateTime DateTimeModified { get; set; }
        public string ModifiedBy { get; set; }  
        public DateTime DateTimeDeleted { get; set; }
        public string DeletedBy { get; set; }
        public int WaitlistedReportID { get; set; }
        public int WithPhoto { get; set; }


        //Below are classes  A Regions,Provinces,Municipalities, and Barangays entity can be related to any number of Masterlist entities.
        

     
  
       
       /*
        public Provinces Provinces { get; set; }
        public Municipalities Municipalities { get; set; }
        public Barangays Barangays { get; set; } 

        public ICollection<GeneralSheet> GeneralSheet { get; set; }
        */
        
       

    }
}
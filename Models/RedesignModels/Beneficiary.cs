using System.ComponentModel.DataAnnotations;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Beneficiary
    {
        public int BeneficiaryID { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Last name cannot be longer than 20 characters.")]
        [Display(Name = "Last Name")]

        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "First name cannot be longer than 20 characters.")]
        //[Column("FirstName")] - This DataAnnotation kay mag puli nan name nan column if ever na sajop ato property page name amu ini way pag rename
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [StringLength(20, ErrorMessage = "Middle name cannot be longer than 20 characters.")]
        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }
        [StringLength(3, ErrorMessage = "Extension name cannot be longer than 3 characters.")]
        [Display(Name = "Extension Name")]
        public string ExtName { get; set; }
        //public int RegionID { get; set; }
        [DataType(DataType.Date)]
        /*The DisplayFormat attribute is used to explicitly specify the date format. 
        The ApplyFormatInEditMode setting specifies that the formatting should also be applied to the edit UI. 
        Some fields shouldn't use ApplyFormatInEditMode. 
        For example, the currency symbol should generally not be displayed in an edit text box.*/
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "ID Number cannot be longer than 20 characters.")]
        [Display(Name = "ID Number")]
        public string IdentificationNumber { get; set; }

        [DataType(DataType.Date)]
        /*The DisplayFormat attribute is used to explicitly specify the date format. 
        The ApplyFormatInEditMode setting specifies that the formatting should also be applied to the edit UI. 
        Some fields shouldn't use ApplyFormatInEditMode. 
        For example, the currency symbol should generally not be displayed in an edit text box.*/
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Issued")]
        public DateTime IdentificationDateIssued { get; set; }

         [StringLength(20, ErrorMessage = "Specific Address name cannot be longer than 20 characters.")]
         [Display(Name = "Specific Address")]
         public string SpecificAddress { get; set; }
        
         [StringLength(11, ErrorMessage = "Phone Number not more than 11 digits.")]
         [DataType(DataType.PhoneNumber)]
         [Display(Name = "Contact Number")]
         public string ContactNumber { get; set; }
         public int HealthStatusID { get; set; }

        [StringLength(50, ErrorMessage = "Health Status not more than 50 characters.")]
        [Display(Name = "Health Remarks")]
         public string HealthRemarks { get; set; }
        /*Sa ubos kay combination of properties kun gusto nim e merge or concatenate an properties 
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return $"{LastName}, {FirstName} {MiddleName} {ExtName}";
            }
        }
       */



        //public int MasterlistID { get; set; }
        //public Masterlist masterlist { get; set; }

        /*One is to Many relationship with Masterlist Entity, isa ra ka name sa Bene an makasuyod
         sa masterlist pero an masterlist mudawat nan dabo na beneficiary, try nat an ICollection*/
        //[JsonIgnore]
        public ICollection<Masterlist> Masterlists { get; set; }

        // Isa ra ka status an kada beneficiary di pwedi able tapos disable, or bedridden.
        public HealthStatus HealthStatus { get; set; }



        //public Validationform Validationform { get; set; }
        //public Masterlist Validationform { get; set; }
        //public int Sex { get; set; }
        //public Region Region { get; set; }

        //Isa  ra ka validation form per bene. dabo man na bene an hatagan so collection
        //public ICollection<ValidationForm> ValidationForms { get; set; }

    }
}
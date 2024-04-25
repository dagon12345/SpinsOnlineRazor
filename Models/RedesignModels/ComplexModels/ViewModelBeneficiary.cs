using System.ComponentModel.DataAnnotations;

namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class ViewModelBeneficiary
    {
        public int? BeneficiaryID { get; set; }
        [Required]
        [StringLength(20, MinimumLength=2, ErrorMessage = "Last name cannot be longer than 20 characters.")]
        [Display(Name = "Last Name")]
       
        public string LastName { get; set; }
        [Required]
        [StringLength(20, MinimumLength=2, ErrorMessage = "First name cannot be longer than 20 characters.")]
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
        public DateTime IdentificationDateIssued { get; set; }
        //Below are Joined table
        public string RegionName { get; set; }
        public string ProvinceName { get; set; }
        public string MunicipalityName { get; set; }
        public int MunicipalityID { get; set; }
        public string BarangayName { get; set; }
        public string IdentificationNo { get; set; }

        
        /*The DisplayFormat attribute is used to explicitly specify the date format. 
        The ApplyFormatInEditMode setting specifies that the formatting should also be applied to the edit UI. 
        Some fields shouldn't use ApplyFormatInEditMode. 
        For example, the currency symbol should generally not be displayed in an edit text box.*/
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Issued")]
        public DateTime IdentificationDate { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }

        //Joined
        public string Sex { get; set; }

        public string MaritalStatus { get; set; }
        //Validation form
        public string Assessment { get; set; }
        //public IFormFile BookPdf { get; set; }
        public int Referencecode { get; set; }
        public int SpinsBatch { get; set; }
        public bool Pantawid { get; set; }
        public bool Indigenous { get; set; }

        //Masterlist
        public string Status { get; set; }
        public int StatusID { get; set; }
        public string IdentificationType { get; set; }

        //Beneficiary model
        public string HealthStatus { get; set; }
        public string Remarks { get; set; }

        //Delete Model
        public bool Deleted { get; set; }

         public int Age { get; set; }

    }
}
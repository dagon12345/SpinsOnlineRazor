using System.ComponentModel.DataAnnotations;

namespace SpinsOnlineRazor.Models.RedesignModels.ComplexModels
{
    public class SaveModelBeneficiary
    {
        //Benficiary Table
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

         //Masterlist Table
           /*EF Core interprets a property as a foreign key if it's named <navigation property name><primary key property name>.
         For example,StudentID is the foreign key for the Student navigation property,
          since the Student entity's primary key is ID. 
          Foreign key properties can also be named <primary key property name>. 
          For example, CourseID since the Course entity's primary key is CourseID.*/
        public int MasterlistID { get; set; }
        //public int BeneficiaryID { get; set; }
        /*The RegionID property is a foreign key, 
        and the corresponding navigation property is Region. 
        An Masterlist entity is associated with one Region entity.*/
        public int RegionID { get; set; }
        /*The ProvinceID property is a foreign key, 
       and the corresponding navigation property is Province. 
       An Masterlist entity is associated with one Province entity.*/
        public int ProvinceID { get; set; }
        /*The MunicipalityID property is a foreign key, 
       and the corresponding navigation property is Municipality. 
       An Masterlist entity is associated with one Municipality entity.*/
        public int MunicipalityID { get; set; }
        /*The BarangayID property is a foreign key, 
       and the corresponding navigation property is Barangay. 
       An Masterlist entity is associated with one Barangay entity.*/
        public int BarangayID { get; set; }
        /*The SexID property is a foreign key, 
       and the corresponding navigation property is Sex. 
       An Masterlist entity is associated with one Sex entity.*/
        public int SexID { get; set; }

        /*The MaritalstatusID property is a foreign key, 
               and the corresponding navigation property is MaritalStatus. 
               An Masterlist entity is associated with one MaritalStatus entity.*/
        public int MaritalstatusID { get; set; }
        public int ValidationformID { get; set; }
        public int StatusID { get; set; }
        public int IdentificationTypeID { get; set; }
        public int DetailID { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using NuGet.Common;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Beneficiary
    {
        public int BeneficiaryID { get; set; }
        public Validationform Validationform { get; set; }//For Valdationform Model BenficiaryID is the KF
        
        public ICollection<Log> Logs { get; set; } // One bene a lot of log

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

        /*The DisplayFormat attribute is used to explicitly specify the date format. 
        The ApplyFormatInEditMode setting specifies that the formatting should also be applied to the edit UI. 
        Some fields shouldn't use ApplyFormatInEditMode. 
        For example, the currency symbol should generally not be displayed in an edit text box.*/
        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Birth Date")]
        //[MinimumAge(60, ErrorMessage = "You must be at least 60 years old.")]
        public DateTime BirthDate { get; set; }

        public int IdentificationTypeID { get; set; }
        public IdentificationType IdentificationType { get; set; }//For ID Model

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
        public HealthStatus HealthStatus { get; set; }

        [StringLength(50, ErrorMessage = "Health Status not more than 50 characters.")]
        [Display(Name = "Health Remarks")]
        public string HealthRemarks { get; set; }
        public int RegionID { get; set; }
        public Region Region { get; set; }//For Region model
        public int ProvinceID { get; set; }
        public Province Province { get; set; }//For province model 
        public int MunicipalityID { get; set; }
        public Municipality Municipality { get; set; }//For Municipality Model
        public int BarangayID { get; set; }
        public Barangay Barangay { get; set; }//For Barangay Model
        public int SexID { get; set; }
        public Sex Sex { get; set; }// For Sex model
        public int MaritalstatusID { get; set; }
        public Maritalstatus Maritalstatus { get; set; }//For marital Model
        public int StatusID { get; set; }
        public string StatusRemarks { get; set; }
        public Status Status { get; set; }//For Status model
                                          // public int? ValidationformID { get; set; }


        public DateTime DateEntered { get; set; }
        public string EnteredBy { get; set; } // Login name
        public DateTime? InclusionDate { get; set; } // Date ACtive from applicant
        public string ExclusionBatch { get; set; } // exclusion date auto increment
        public DateTime? ExclusionDate { get; set; } // date delisted
        public DateTime? DeceasedDate { get; set; } // date of death
        public string ModifiedBy { get; set; } // login name
        public DateTime? ModifiedDate { get; set; } // date edited
        public bool IsDeleted { get; set; }// boolean soft delete
        public DateTime? DeletedDate { get; set; } // date deleted
        public string DeletedBy { get; set; } // login name
    }
}
using System.Drawing;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Models.RedesignModels
{
    public class Masterlist
    {
        /*EF Core interprets a property as a foreign key if it's named <navigation property name><primary key property name>.
         For example,StudentID is the foreign key for the Student navigation property,
          since the Student entity's primary key is ID. 
          Foreign key properties can also be named <primary key property name>. 
          For example, CourseID since the Course entity's primary key is CourseID.*/
        public int MasterlistID { get; set; }
        public int BeneficiaryID { get; set; }
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
        //Isa ra ija dawaton na entity isa ka Beneficiary,Region,Province,Municipality, and Barangay. So Entity below
        /*An Masterlist entity is associated with one Beneficiary entity, so the property contains a single Beneficiary entity.*/
        public Beneficiary Beneficiary { get; set; }
        public Region Region { get; set; }
        public Province Province { get; set; }
        public Municipality Municipality { get; set; }
        public Barangay Barangay { get; set; }

        //Isa ra ka sex and MaritalStatus per masterlist an madawat diri dili pwedi baje yaki an sex and duha ka marital nan isa ka bene so isa ra.
        public Sex Sex { get; set; }
        public Maritalstatus Maritalstatus { get; set; }

        //Isa ra ka validation form per masterlist di mag dabo
        public Validationform Validationform { get; set; }
        // Isa ra ka Status per masterlist di mag dabo
        public Status Status { get; set; }
        public IdentificationType IdentificationType { get; set; }

        //DetailID per masterlist
        public Detail Detail { get; set; }

    }
}
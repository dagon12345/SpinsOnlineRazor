using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Data
{
  public class DbInitializer
  {
    public static void Initialize(SpinsContext context)
    {
      // Look for any students.
      if (context.Beneficiaries.Any())
      {
        return;   // DB has been seeded
      }

      var regions = new Region[]
      {
          new Region{RegionID=10000000,Name="Region I (Ilocos Region)"},
          new Region{RegionID=20000000,Name="Region II (Cagayan Valley)"},
          new Region{RegionID=30000000,Name="Region III (Central Luzon)"},
          new Region{RegionID=40000000,Name="Region IV-A (CALABARZON)"},
          new Region{RegionID=50000000,Name="Region V (Bicol Region)"},
          new Region{RegionID=60000000,Name="Region VI (Western Visayas)"},
          new Region{RegionID=70000000,Name="Region VII (Central Visayas)"},
          new Region{RegionID=80000000,Name="Region VIII (Eastern Visayas)"},
          new Region{RegionID=90000000,Name="Region IX (Zamboanga Peninsula)"},
          new Region{RegionID=100000000,Name="Region X (Northern Mindanao)"},
          new Region{RegionID=110000000,Name="Region XI (Davao Region)"},
          new Region{RegionID=120000000,Name="Region XII (SOCCSKSARGEN)"},
          new Region{RegionID=130000000,Name="National Capital Region (NCR)"},
          new Region{RegionID=140000000,Name="Cordillera Administrative Region (CAR)"},
          new Region{RegionID=150000000,Name="Bangsamoro Autonomous Region In Muslim Mindanao (BARMM)"},
          new Region{RegionID=160000000,Name="Region XIII (Caraga)"},
          new Region{RegionID=170000000,Name="MIMAROPA Region"}

      };

      context.Regions.AddRange(regions);
      context.SaveChanges();

      var provinces = new Province[]
      {
                  new Province{ProvinceID=160200000,Name="Agusan del Norte",RegionID=160000000},
                  new Province{ProvinceID=160300000,Name="Agusan del Sur",RegionID=160000000},
                  new Province{ProvinceID=166700000,Name="Surigao del Norte",RegionID=160000000},
                  new Province{ProvinceID=166800000,Name="Surigao del Sur",RegionID=160000000},
                  new Province{ProvinceID=168500000,Name="Dinagat Islands",RegionID=160000000},

      };

      context.Provinces.AddRange(provinces);
      context.SaveChanges();

      var municipalities = new Municipality[]
     {
                  new Municipality{MunicipalityID=160201000,Name="Buenavista",ProvinceID=160200000},
                  new Municipality{MunicipalityID=160301000,Name="City of Bayugan",ProvinceID=160300000},
                  new Municipality{MunicipalityID=166701000,Name="Alegria",ProvinceID=166700000},
                  new Municipality{MunicipalityID=166801000,Name="Barobo",ProvinceID=166800000},
                  new Municipality{MunicipalityID=168501000,Name="Basilisa (Rizal)",ProvinceID=168500000},

     };

      context.Municipalities.AddRange(municipalities);
      context.SaveChanges();


      var barangays = new Barangay[]
    {
                  new Barangay{BarangayID=160301001,Name="Calaitan",MunicipalityID=160301000},
                  new Barangay{BarangayID=160201001,Name="Abilan",MunicipalityID=160201000},
                  new Barangay{BarangayID=166701001,Name="Poblacion (Alegria)",MunicipalityID=166701000},
                  new Barangay{BarangayID=166801001,Name="Amaga",MunicipalityID=166801000},
                  new Barangay{BarangayID=168501002,Name="Catadman",MunicipalityID=168501000},

    };

      context.Barangays.AddRange(barangays);
      context.SaveChanges();

      var sexes = new Sex[]
                {
                  new Sex{SexID=1,Name="Male"},
                  new Sex{SexID=2,Name="Female"},
                };

      context.Sexes.AddRange(sexes);
      context.SaveChanges();

      var maritalstatuses = new Maritalstatus[]
     {
                  new Maritalstatus{MaritalstatusID=1,Name="Single"},
                  new Maritalstatus{MaritalstatusID=2,Name="Married"},
                  new Maritalstatus{MaritalstatusID=3,Name="Widowed"},
                  new Maritalstatus{MaritalstatusID=4,Name="Separated"},
                  new Maritalstatus{MaritalstatusID=5,Name="Widower"},
                  new Maritalstatus{MaritalstatusID=6,Name="CommonLaw"},
     };

      context.Maritalstatuses.AddRange(maritalstatuses);
      context.SaveChanges();

      var statuses = new Status[]
      {
      new Status{StatusID=1,Name="Active"},
      new Status{StatusID=2,Name="Deceased"},
      new Status{StatusID=3,Name="Pensioner"},
      new Status{StatusID=4,Name="Financially Stable"},
      new Status{StatusID=5,Name="Transferred Residence"},
      new Status{StatusID=6,Name="Duplicate"},
      new Status{StatusID=7,Name="Under Age"},
      new Status{StatusID=8,Name="Unknown"},
      new Status{StatusID=9,Name="Out of Town"},
      new Status{StatusID=10,Name="Imprison"},
      new Status{StatusID=11,Name="Waived/Not Interested"},
      new Status{StatusID=12,Name="Delisted"},
      new Status{StatusID=13,Name="Pending"},
      new Status{StatusID=14,Name="Inactive"},
      new Status{StatusID=15,Name="With Honorarium"},
      new Status{StatusID=99,Name="Applicant"},

      };

      context.Statuses.AddRange(statuses);
      context.SaveChanges();


        var eligible = new Assessment
        {
          AssessmentID = 1,
          Name = "Eligible"
        };
        var drop = new Assessment
        {
          AssessmentID = 2,
          Name = "Drop/Not Eligible"

        };
        var pending = new Assessment
        {
          AssessmentID = 3,
          Name = "Pending - Revalidate"

        };
        var deceased = new Assessment
        {
          AssessmentID = 4,
          Name = "Deceased"
        };
        var assessments = new Assessment[]
       {
                  eligible,
                  drop,
                  pending,
                  deceased
       };

        context.Assessments.AddRange(assessments);
        context.SaveChanges();




      var identificationTypes = new IdentificationType[]
{
                new IdentificationType{IdentificationTypeID=1,Name="OSCA"},
                new IdentificationType{IdentificationTypeID=2,Name="FSCAP"},
                new IdentificationType{IdentificationTypeID=3,Name="VOTERS ID"},
                new IdentificationType{IdentificationTypeID=4,Name="PHIC"},
                new IdentificationType{IdentificationTypeID=5,Name="DRIVERS LICENSE"},
                new IdentificationType{IdentificationTypeID=6,Name="PWD"},
                new IdentificationType{IdentificationTypeID=7,Name="PANTAWID"},
                new IdentificationType{IdentificationTypeID=8,Name="POSTAL"},
                new IdentificationType{IdentificationTypeID=9,Name="TIN"},
};

      context.IdentificationTypes.AddRange(identificationTypes);
      context.SaveChanges();

      var healthstatuses = new HealthStatus[]
 {
                new HealthStatus{HealthStatusID=1,Name="Bedridden"},
                new HealthStatus{HealthStatusID=2,Name="Frail/ Sickly"},
                new HealthStatus{HealthStatusID=4,Name="Able"},
                new HealthStatus{HealthStatusID=5,Name="PWD"},

 };

      context.HealthStatuses.AddRange(healthstatuses);
      context.SaveChanges();

      //






      var espina = new Beneficiary
      {
        BeneficiaryID = 1,
        LastName = "ESPINA",
        FirstName = "LANCE ANDREI",
        MiddleName = "URIARTE",
        ExtName = "",
        BirthDate = DateTime.Parse("1938-09-30"),
        IdentificationTypeID = 1,
        IdentificationNumber = "T57948",
        IdentificationDateIssued = DateTime.Parse("2023-09-15"),
        SpecificAddress = "Purok-2",
        ContactNumber = "09123456789",
        HealthStatusID = 1,
        HealthRemarks = "Bed ridden",
        RegionID = 160000000,
        ProvinceID = 160200000,
        MunicipalityID = 160201000,
        BarangayID = 160201001,
        SexID = 1,
        MaritalstatusID = 1,
        StatusID = 99,
        DateEntered = DateTime.Parse("2024-04-20"),
        EnteredBy = "Unknown",
        InclusionDate = DateTime.Parse("2024-04-20"),
        ExclusionBatch = "",
        ExclusionDate = null,
        DeceasedDate = null,
        ModifiedBy = "Unknown",
        ModifiedDate = null,
        IsDeleted = false,
        DeletedDate =   null,
        DeletedBy = "",



      };
      var alquizar = new Beneficiary
      {
         BeneficiaryID = 2,
        LastName = "ALQUIZAR",
        FirstName = "CORNELIA",
        MiddleName = "ONYOT",
        ExtName = "",
        BirthDate = DateTime.Parse("1939-10-29"),
        IdentificationTypeID = 2,
        IdentificationNumber = "T57930",
        IdentificationDateIssued = DateTime.Parse("2023-10-30"),
        SpecificAddress = "Purok-3",
        ContactNumber = "09123456789",
        HealthStatusID = 2,
        HealthRemarks = "Sick",
        RegionID = 160000000,
        ProvinceID = 160200000,
        MunicipalityID = 160201000,
        BarangayID = 160201001,
        SexID = 1,
        MaritalstatusID = 1,
        StatusID = 1,
        DateEntered = DateTime.Parse("2024-04-20"),
        EnteredBy = "Unknown",
        InclusionDate = DateTime.Parse("2024-04-20"),
        ExclusionBatch = "",
        ExclusionDate = null,
        DeceasedDate = null,
        ModifiedBy = "Unknown",
        ModifiedDate = null,
        IsDeleted = false,
        DeletedDate =   null,
        DeletedBy = "",

      };
      var amemenzi = new Beneficiary
      {
         BeneficiaryID = 3,
        LastName = "AMEMENZI",
        FirstName = "MARIA",
        MiddleName = "JAIME",
        ExtName = "",
        BirthDate = DateTime.Parse("1940-11-28"),
        IdentificationTypeID = 3,
        IdentificationNumber = "T57929",
        IdentificationDateIssued = DateTime.Parse("2023-11-30"),
        SpecificAddress = "Purok-4",
        ContactNumber = "09123456789",
        HealthStatusID = 4,
        HealthRemarks = "Healthy",
        RegionID = 160000000,
        ProvinceID = 160200000,
        MunicipalityID = 160201000,
        BarangayID = 160201001,
        SexID = 1,
        MaritalstatusID = 1,
        StatusID = 1,
        DateEntered = DateTime.Parse("2024-04-20"),
        EnteredBy = "Unknown",
        InclusionDate = DateTime.Parse("2024-04-20"),
        ExclusionBatch = "",
        ExclusionDate = null,
        DeceasedDate = null,
        ModifiedBy = "Unknown",
        ModifiedDate = null,
        IsDeleted = false,
        DeletedDate =   null,
        DeletedBy = "",

      };
      var balingit = new Beneficiary
      {
        BeneficiaryID = 4,
        LastName = "BALINGIT",
        FirstName = "CIPRIANO",
        MiddleName = "CIBALLOS",
        ExtName = "",
        BirthDate = DateTime.Parse("1941-12-27"),
        IdentificationTypeID = 4,
        IdentificationNumber = "T57902",
        IdentificationDateIssued = DateTime.Parse("2023-12-30"),
        SpecificAddress = "Purok-5",
        ContactNumber = "09123456789",
        HealthStatusID = 5,
        HealthRemarks = "Can't walk",
        RegionID = 160000000,
        ProvinceID = 160200000,
        MunicipalityID = 160201000,
        BarangayID = 160201001,
        SexID = 1,
        MaritalstatusID = 1,
        StatusID = 1,
        DateEntered = DateTime.Parse("2024-04-20"),
        EnteredBy = "Unknown",
        InclusionDate = DateTime.Parse("2024-04-20"),
        ExclusionBatch = "",
        ExclusionDate = null,
        DeceasedDate = null,
        ModifiedBy = "Unknown",
        ModifiedDate = null,
        IsDeleted = false,
        DeletedDate =   null,
        DeletedBy = "",
      };
      var beneficiaries = new Beneficiary[]
     {
        espina,
        alquizar,
        amemenzi,
        balingit
     };

      context.Beneficiaries.AddRange(beneficiaries);
      context.SaveChanges();


      
      var validationforms = new Validationform[]
      {
          new Validationform{ValidationformID=11,BeneficiaryID=1,ReferenceCode=21031243,SpinsBatch=98,AssessmentID=1,Pantawid=true,Indigenous=true},
          new Validationform{ValidationformID=12,BeneficiaryID=2,ReferenceCode=21031242,SpinsBatch=98,AssessmentID=3,Pantawid=false,Indigenous=true},
          new Validationform{ValidationformID=13,BeneficiaryID=3,ReferenceCode=21031241,SpinsBatch=99,AssessmentID=4,Pantawid=true,Indigenous=false},
          new Validationform{ValidationformID=14,BeneficiaryID=4,ReferenceCode=21031240,SpinsBatch=99,AssessmentID=2,Pantawid=false,Indigenous=true},


       };

      context.Validationforms.AddRange(validationforms);
      context.SaveChanges();

    }
  }
}

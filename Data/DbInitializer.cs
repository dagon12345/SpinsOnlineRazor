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
                new Region{RegionID=160000000,Name="Region XIII (Caraga)"},

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

      context.MaritalStatuses.AddRange(maritalstatuses);
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

               //////////////////////////////////////////////////////////
      var deceaseds = new Deceased[]
             {
                new Deceased{DeceasedID=1,IsDeceased=true,DeceasedDate=DateTime.Parse("2024-04-09")},
                new Deceased{DeceasedID=3,IsDeceased=true,DeceasedDate=DateTime.Parse("2024-04-11")},
                new Deceased{DeceasedID=5,IsDeceased=true,DeceasedDate=DateTime.Parse("2024-04-16")},
                new Deceased{DeceasedID=7,IsDeceased=true,DeceasedDate=DateTime.Parse("2024-04-17")},
              

             };

      context.Deceaseds.AddRange(deceaseds);
      context.SaveChanges();


      //////////////////////////////////////////////////////////
      ///

         //////////////////////////////////////////////////////////
      var exclusions = new Exclusion[]
             {
                new Exclusion{ExclusionID=1,IsExcluded=true,ExclusionBatch="2024-1S",ExclusionDate=DateTime.Parse("2024-04-14")},
                new Exclusion{ExclusionID=3,IsExcluded=true,ExclusionBatch="2024-1S",ExclusionDate=DateTime.Parse("2024-04-15")},
                new Exclusion{ExclusionID=5,IsExcluded=true,ExclusionBatch="2024-1S",ExclusionDate=DateTime.Parse("2024-04-16")},
                new Exclusion{ExclusionID=7,IsExcluded=true,ExclusionBatch="2024-1S",ExclusionDate=DateTime.Parse("2024-04-17")},
              

             };

      context.Exclusions.AddRange(exclusions);
      context.SaveChanges();

      
         //////////////////////////////////////////////////////////
      var modifies = new Modify[]
             {
                new Modify{ModifyID=1,IsModified=true,ModifiedBy="LANCE",ModifiedDate=DateTime.Parse("2024-04-18")},
                new Modify{ModifyID=2,IsModified=true,ModifiedBy="ANDREI",ModifiedDate=DateTime.Parse("2024-04-18")},
                new Modify{ModifyID=3,IsModified=true,ModifiedBy="URIARTE",ModifiedDate=DateTime.Parse("2024-04-18")},
                new Modify{ModifyID=4,IsModified=true,ModifiedBy="ESPINA",ModifiedDate=DateTime.Parse("2024-04-17")},
                new Modify{ModifyID=5,IsModified=true,ModifiedBy="ESPINA",ModifiedDate=DateTime.Parse("2024-04-16")},
                new Modify{ModifyID=6,IsModified=true,ModifiedBy="LANCE",ModifiedDate=DateTime.Parse("2024-04-16")},
                new Modify{ModifyID=7,IsModified=true,ModifiedBy="ANDREI",ModifiedDate=DateTime.Parse("2024-04-16")},
                new Modify{ModifyID=8,IsModified=true,ModifiedBy="URIARTE",ModifiedDate=DateTime.Parse("2024-04-16")},
              
             };

      context.Modifies.AddRange(modifies);
      context.SaveChanges();


      //////////////////////////////////////////////////////////
    var deletes = new Delete[]
             {
                new Delete{DeleteID=1,IsDeleted=true,DeletedDate=DateTime.Parse("2024-04-14")}
              
             };

      context.Deletes.AddRange(deletes);
      context.SaveChanges();

      
      var details = new Detail[]
             {
                new Detail{DetailID=1,DateEntered=DateTime.Parse("2024-04-14"),EnteredBy="LANCE",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=1,DeceasedID=1,ModifyID=1,DeleteID=1},
                new Detail{DetailID=2,DateEntered=DateTime.Parse("2024-04-14"),EnteredBy="ANDREI",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=null,DeceasedID=null,ModifyID=2,DeleteID=null},
                new Detail{DetailID=3,DateEntered=DateTime.Parse("2024-09-14"),EnteredBy="ESPINA",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=3,DeceasedID=3,ModifyID=3,DeleteID=null},
                new Detail{DetailID=4,DateEntered=DateTime.Parse("2024-09-14"),EnteredBy="ESPINA",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=null,DeceasedID=null,ModifyID=4,DeleteID=null},
                new Detail{DetailID=5,DateEntered=DateTime.Parse("2024-09-14"),EnteredBy="ANDREI",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=5,DeceasedID=5,ModifyID=5,DeleteID=null},
                new Detail{DetailID=6,DateEntered=DateTime.Parse("2024-09-14"),EnteredBy="LANCE",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=null,DeceasedID=null,ModifyID=6,DeleteID=null},
                new Detail{DetailID=7,DateEntered=DateTime.Parse("2024-09-14"),EnteredBy="ESPINA",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=7,DeceasedID=7,ModifyID=7,DeleteID=null},
                new Detail{DetailID=8,DateEntered=DateTime.Parse("2024-09-14"),EnteredBy="ANDREI",InclusionDate=DateTime.Parse("2024-04-14"),ExclusionID=null,DeceasedID=null,ModifyID=8,DeleteID=null},

             };

      context.Details.AddRange(details);
      context.SaveChanges();

      ///
      var validationforms = new Validationform[]
                           {
                            new Validationform{ValidationformID=10,ReferenceCode=21031243,SpinsBatch=98,AssessmentID=1,Pantawid=true,Indigenous=true},
                            new Validationform{ValidationformID=20,ReferenceCode=21031242,SpinsBatch=98,AssessmentID=3,Pantawid=false,Indigenous=true},
                            new Validationform{ValidationformID=30,ReferenceCode=21031241,SpinsBatch=99,AssessmentID=4,Pantawid=true,Indigenous=false},
                            new Validationform{ValidationformID=40,ReferenceCode=21031240,SpinsBatch=99,AssessmentID=2,Pantawid=false,Indigenous=true},
                            new Validationform{ValidationformID=50,ReferenceCode=21031239,SpinsBatch=100,AssessmentID=1,Pantawid=true,Indigenous=false},
                            new Validationform{ValidationformID=60,ReferenceCode=21031238,SpinsBatch=100,AssessmentID=2,Pantawid=false,Indigenous=true},
                            new Validationform{ValidationformID=70,ReferenceCode=21031237,SpinsBatch=101,AssessmentID=3,Pantawid=true,Indigenous=false},
                            new Validationform{ValidationformID=80,ReferenceCode=21031236,SpinsBatch=101,AssessmentID=4,Pantawid=false,Indigenous=true},

                           };

      context.Validationforms.AddRange(validationforms);
      context.SaveChanges();


      var beneficiaries = new Beneficiary[]
      {
                new Beneficiary{LastName="ESPINA",FirstName="LANCE ANDREI",MiddleName="URIARTE",ExtName="",BirthDate=DateTime.Parse("1938-09-30"),IdentificationNumber="T57948",IdentificationDateIssued=DateTime.Parse("2023-09-15"),SpecificAddress="Purok-2",ContactNumber="09123456789",HealthStatusID=1,HealthRemarks="Bed ridden"},
                new Beneficiary{LastName="ALQUIZAR",FirstName="CORNELIA",MiddleName="ONYOT",ExtName="",BirthDate=DateTime.Parse("1939-10-29"),IdentificationNumber="T57930",IdentificationDateIssued=DateTime.Parse("2023-10-30"),SpecificAddress="Purok-3",ContactNumber="09123456789",HealthStatusID=2,HealthRemarks="Sick"},
                new Beneficiary{LastName="AMEMENZI",FirstName="MARIA",MiddleName="JAIME",ExtName="",BirthDate=DateTime.Parse("1940-11-28"),IdentificationNumber="T57929",IdentificationDateIssued=DateTime.Parse("2023-11-30"),SpecificAddress="Purok-4",ContactNumber="09123456789",HealthStatusID=4,HealthRemarks="Healthy"},
                new Beneficiary{LastName="BALINGIT",FirstName="CIPRIANO",MiddleName="CIBALLOS",ExtName="",BirthDate=DateTime.Parse("1941-12-27"),IdentificationNumber="T57902",IdentificationDateIssued=DateTime.Parse("2023-12-30"),SpecificAddress="Purok-5",ContactNumber="09123456789",HealthStatusID=5,HealthRemarks="Can't walk"},
                new Beneficiary{LastName="BELLEZA",FirstName="ERNESTO",MiddleName="TEOLOGO",ExtName="",BirthDate=DateTime.Parse("1942-01-26"),IdentificationNumber="T57895",IdentificationDateIssued=DateTime.Parse("2023-01-30"),SpecificAddress="Purok-2",ContactNumber="09123456789",HealthStatusID=4,HealthRemarks="Healthy"},
                new Beneficiary{LastName="BELTIS",FirstName="ANICITA",MiddleName="RONQUILLO",ExtName="",BirthDate=DateTime.Parse("1943-02-25"),IdentificationNumber="T57867",IdentificationDateIssued=DateTime.Parse("2023-02-12"),SpecificAddress="Purok-3",ContactNumber="09123456789",HealthStatusID=4,HealthRemarks="Healthy"},
                new Beneficiary{LastName="BERNANTE",FirstName="ESMERALDA",MiddleName="SAN PABLO",ExtName="",BirthDate=DateTime.Parse("1944-03-24"),IdentificationNumber="T57537",IdentificationDateIssued=DateTime.Parse("2023-03-30"),SpecificAddress="Purok-1",ContactNumber="09123456789",HealthStatusID=4,HealthRemarks="Healthy"},
                new Beneficiary{LastName="CABIGON",FirstName="CANCIO",MiddleName="OBEDENCIO",ExtName="",BirthDate=DateTime.Parse("1945-04-23"),IdentificationNumber="T57429",IdentificationDateIssued=DateTime.Parse("2023-04-30"),SpecificAddress="Purok-2",ContactNumber="09123456789",HealthStatusID=2,HealthRemarks="Sickly"},
      };


      context.Beneficiaries.AddRange(beneficiaries);
      context.SaveChanges();


      var masterlists = new Masterlist[]
    {
                new Masterlist{BeneficiaryID=1,RegionID=160000000,ProvinceID=160200000,MunicipalityID=160201000,BarangayID=160201001,SexID=1,MaritalstatusID=1,ValidationformID=10,StatusID=1,IdentificationTypeID=1,DetailID=1},
                new Masterlist{BeneficiaryID=2,RegionID=160000000,ProvinceID=160300000,MunicipalityID=160301000,BarangayID=160301001,SexID=2,MaritalstatusID=2,ValidationformID=20,StatusID=2,IdentificationTypeID=1,DetailID=2},
                new Masterlist{BeneficiaryID=3,RegionID=160000000,ProvinceID=166700000,MunicipalityID=166701000,BarangayID=166701001,SexID=2,MaritalstatusID=3,ValidationformID=30,StatusID=3,IdentificationTypeID=1,DetailID=3},
                new Masterlist{BeneficiaryID=4,RegionID=160000000,ProvinceID=166800000,MunicipalityID=166801000,BarangayID=166801001,SexID=1,MaritalstatusID=4,ValidationformID=40,StatusID=4,IdentificationTypeID=1,DetailID=4},
                new Masterlist{BeneficiaryID=5,RegionID=160000000,ProvinceID=168500000,MunicipalityID=168501000,BarangayID=168501002,SexID=2,MaritalstatusID=5,ValidationformID=50,StatusID=5,IdentificationTypeID=1,DetailID=5},
                new Masterlist{BeneficiaryID=6,RegionID=160000000,ProvinceID=160200000,MunicipalityID=160201000,BarangayID=160201001,SexID=1,MaritalstatusID=6,ValidationformID=60,StatusID=1,IdentificationTypeID=1,DetailID=6},
                new Masterlist{BeneficiaryID=7,RegionID=160000000,ProvinceID=160300000,MunicipalityID=160301000,BarangayID=160301001,SexID=2,MaritalstatusID=1,ValidationformID=70,StatusID=2,IdentificationTypeID=1,DetailID=7},
                new Masterlist{BeneficiaryID=8,RegionID=160000000,ProvinceID=166700000,MunicipalityID=166701000,BarangayID=166701001,SexID=1,MaritalstatusID=2,ValidationformID=80,StatusID=99,IdentificationTypeID=1,DetailID=8},

    };

      context.Masterlists.AddRange(masterlists);
      context.SaveChanges();

    }
  }
}

using SpinsOnlineRazor.Models.RedesignModels;

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

            var beneficiaries = new Beneficiary[]
            {
                new Beneficiary{LastName="ESPINA",FirstName="LANCE ANDREI",MiddleName="URIARTE",ExtName="",BirthDate=DateTime.Parse("1938-09-30")},
                new Beneficiary{LastName="ALQUIZAR",FirstName="CORNELIA",MiddleName="ONYOT",ExtName="",BirthDate=DateTime.Parse("1939-10-29")},
                new Beneficiary{LastName="AMEMENZI",FirstName="MARIA",MiddleName="JAIME",ExtName="",BirthDate=DateTime.Parse("1940-11-28")},
                new Beneficiary{LastName="BALINGIT",FirstName="CIPRIANO",MiddleName="CIBALLOS",ExtName="",BirthDate=DateTime.Parse("1941-12-27")},
                new Beneficiary{LastName="BELLEZA",FirstName="ERNESTO",MiddleName="TEOLOGO",ExtName="",BirthDate=DateTime.Parse("1942-01-26")},
                new Beneficiary{LastName="BELTIS",FirstName="ANICITA",MiddleName="RONQUILLO",ExtName="",BirthDate=DateTime.Parse("1943-02-25")},
                new Beneficiary{LastName="BERNANTE",FirstName="ESMERALDA",MiddleName="SAN PABLO",ExtName="",BirthDate=DateTime.Parse("1944-03-24")},
                new Beneficiary{LastName="CABIGON",FirstName="CANCIO",MiddleName="OBEDENCIO",ExtName="",BirthDate=DateTime.Parse("1945-04-23")},
            };

            context.Beneficiaries.AddRange(beneficiaries);
            context.SaveChanges();

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


               var masterlists = new Masterlist[]
            {
                new Masterlist{BeneficiaryID=1,RegionID=160000000,ProvinceID=160200000,MunicipalityID=160201000,BarangayID=160201001},
                new Masterlist{BeneficiaryID=2,RegionID=160000000,ProvinceID=160300000,MunicipalityID=160301000,BarangayID=160301001},
                new Masterlist{BeneficiaryID=3,RegionID=160000000,ProvinceID=166700000,MunicipalityID=166701000,BarangayID=166701001},
                new Masterlist{BeneficiaryID=4,RegionID=160000000,ProvinceID=166800000,MunicipalityID=166801000,BarangayID=166801001},
                new Masterlist{BeneficiaryID=5,RegionID=160000000,ProvinceID=168500000,MunicipalityID=168501000,BarangayID=168501002},
                new Masterlist{BeneficiaryID=6,RegionID=160000000,ProvinceID=160200000,MunicipalityID=160201000,BarangayID=160201001},
                new Masterlist{BeneficiaryID=7,RegionID=160000000,ProvinceID=160300000,MunicipalityID=160301000,BarangayID=160301001},
                new Masterlist{BeneficiaryID=8,RegionID=160000000,ProvinceID=166700000,MunicipalityID=166701000,BarangayID=166701001},
          
            };

            context.Masterlists.AddRange(masterlists);
            context.SaveChanges();

/*
            var validationforms = new ValidationForm[]
            {
                new ValidationForm{BeneficiaryID=1,AssessmentID=1,ReferenceCode=21031243,SpinsBatch=98},
                new ValidationForm{BeneficiaryID=2,AssessmentID=2,ReferenceCode=21031242,SpinsBatch=98},
                new ValidationForm{BeneficiaryID=3,AssessmentID=3,ReferenceCode=21031241,SpinsBatch=99},
                new ValidationForm{BeneficiaryID=4,AssessmentID=4,ReferenceCode=21031240,SpinsBatch=99},
                new ValidationForm{BeneficiaryID=5,AssessmentID=4,ReferenceCode=21031239,SpinsBatch=100},
                new ValidationForm{BeneficiaryID=6,AssessmentID=3,ReferenceCode=21031238,SpinsBatch=100},
                new ValidationForm{BeneficiaryID=7,AssessmentID=2,ReferenceCode=21031237,SpinsBatch=101},
                new ValidationForm{BeneficiaryID=8,AssessmentID=1,ReferenceCode=21031236,SpinsBatch=101},
          
            };

            context.ValidationForms.AddRange(validationforms);
            context.SaveChanges();

              var assessments = new Assessment[]
            {
                new Assessment{AssessmentID=1,Name="Eligible"},
                new Assessment{AssessmentID=2,Name="Drop/Not Eligible"},
                new Assessment{AssessmentID=3,Name="Pending - Revalidate"},
                new Assessment{AssessmentID=4,Name="Deceased"},
          
            };

            context.Assessments.AddRange(assessments);
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
*/
        }
    }
}

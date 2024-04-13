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
                new Beneficiary{LastName="ESPINA",FirstName="LANCE ANDREI",MiddleName="URIARTE",ExtName=""},
                new Beneficiary{LastName="ALQUIZAR",FirstName="CORNELIA",MiddleName="ONYOT",ExtName=""},
                new Beneficiary{LastName="AMEMENZI",FirstName="MARIA",MiddleName="JAIME",ExtName=""},
                new Beneficiary{LastName="BALINGIT",FirstName="CIPRIANO",MiddleName="CIBALLOS",ExtName=""},
                new Beneficiary{LastName="BELLEZA",FirstName="ERNESTO",MiddleName="TEOLOGO",ExtName=""},
                new Beneficiary{LastName="BELTIS",FirstName="ANICITA",MiddleName="RONQUILLO",ExtName=""},
                new Beneficiary{LastName="BERNANTE",FirstName="ESMERALDA",MiddleName="SAN PABLO",ExtName=""},
                new Beneficiary{LastName="CABIGON",FirstName="CANCIO",MiddleName="OBEDENCIO",ExtName=""},
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

        }
    }
}

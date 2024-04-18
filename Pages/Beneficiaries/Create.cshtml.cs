using Microsoft.AspNetCore.Mvc;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.Dropdowns;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class CreateModel : IdentificationTypeNamePageModel
    {
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public CreateModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            PopulateIndetificationDropDownList(_context);
            return Page();
        }
        //Later for uploading GIS
        /*public async Task<IActionResult> AddNewValidation(Validationform validationformModel)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         if (validationformModel.BookPdf != null)
        //         {
        //             string folder = "wwwroot/pdf/";
        //             string filePath = await UploadImage(folder, validationformModel.BookPdf);
        //             // Assuming ReferenceCode is an int field, you need to convert the filePath to an int.
        //             if (int.TryParse(filePath, out int referenceCode))
        //             {
        //                 validationformModel.ReferenceCode = referenceCode;
        //             }
        //             else
        //             {
        //                 // Handle the case where the conversion fails
        //                 // For example, you could log an error or set a default value.
        //                 // For now, let's set it to 0.
        //                 validationformModel.ReferenceCode = 0;
        //             }
        //         }

        //         if (await TryUpdateModelAsync<Validationform>(validationformModel, "Validationform", s => s.ReferenceCode))
        //         {
        //             _context.Validationforms.Add(validationformModel);
        //             await _context.SaveChangesAsync();
        //             return RedirectToPage("./Index");
        //         }
        //     }

        //     return Page();
        // } 

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            // Assuming you want to return the reference code (which is part of the file path) as a string.
            return folderPath;
        }
*/

        [BindProperty]
        public Beneficiary Beneficiary { get; set; } = default!;
         [BindProperty]
        public Masterlist Masterlist { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            /*
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Beneficiaries.Add(Beneficiary);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            */


            /*Uses the posted form values from the PageContext property in the PageModel.
                Updates only the properties listed (s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate).
                Looks for form fields with a "student" prefix.
                For example, Student.FirstMidName. It's not case sensitive.
                Uses the model binding system to convert form values from strings to the types in the Student model. 
                For example, EnrollmentDate is converted to DateTime.*/

            //Code below disables the overposting, para sa mga hackers maka set sila nan data like bisan not eligible e eligible
            var emptyBeneficiary = new Beneficiary();

            if (await TryUpdateModelAsync<Beneficiary>(emptyBeneficiary, "beneficiary", s => s.LastName, s => s.FirstName,
             s => s.MiddleName, s => s.ExtName, s => s.BirthDate, s => s.IdentificationNumber,
             s => s.IdentificationDateIssued, s => s.SpecificAddress, s => s.ContactNumber,s => s.HealthStatusID, s => s.HealthRemarks
             ))
            {
                _context.Beneficiaries.Add(emptyBeneficiary);
                await _context.SaveChangesAsync();
                //return RedirectToPage("./Index");
            }

             var emptyMasterlist = new Masterlist();

            if (await TryUpdateModelAsync<Masterlist>(emptyMasterlist, "Masterlist", s => s.RegionID, s => s.ProvinceID,
             s => s.MunicipalityID, s => s.BarangayID, s => s.SexID, s => s.MaritalstatusID, s => s.StatusID, s => s.IdentificationTypeID
             ))
            {
                _context.Masterlists.Add(emptyMasterlist);
                await _context.SaveChangesAsync();
               // return RedirectToPage("./Index");
            }

            return RedirectToPage("./Index");
        }
    }
}

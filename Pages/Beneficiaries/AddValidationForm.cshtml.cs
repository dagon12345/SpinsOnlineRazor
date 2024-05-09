using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class AddValidationForm : PageModel
    {

        private readonly SpinsContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public AddValidationForm(SpinsContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        [BindProperty]
        public BufferedSingleFileUploadDb FileUpload { get; set; }

        public class BufferedSingleFileUploadDb
        {
            //[Display(Name = "Upload your Validation Form in pdf format")]
            [Required]
            public IFormFile GisPdf { get; set; }
        }



        // public Beneficiary Beneficiary { get; set; }
        public Validationform Validationform { get; set; }

        public SelectList AssessmentSL { get; set; }
        private void PopulateDropDownLists()
        {
            AssessmentSL = new SelectList(_context.Assessments.OrderBy(h => h.Name), nameof(Assessment.AssessmentID), nameof(Assessment.Name));
        }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            PopulateDropDownLists();
            if (id == null)
            {
                return NotFound();
            }
            Validationform = await _context.Validationforms
            .AsNoTracking()
            .Include(p => p.Beneficiary)
            .FirstOrDefaultAsync(m => m.BeneficiaryID == id);

            if (Validationform == null)
            {
                return NotFound();
            }
            
            return Page();
        }

        private int GenerateReferenceCode()
        {
            // Get the current date components
            int year = DateTime.Now.Year % 100; // Get the last two digits of the year
            int month = DateTime.Now.Month;
            int day = DateTime.Now.Day;

            // Generate four random numbers
            Random random = new Random();
            int randomNumbers = random.Next(100000); // Generate a random number between 0 and 99999

            // Combine the date components and random numbers to form the reference code
            int referenceCode = year * 1000000 + month * 10000 + day * 100 + randomNumbers;

            return referenceCode;
        }



        public async Task<IActionResult> OnPostAsync(int? id)
        {



            var validationFormToUpdate = await _context.Validationforms
            .Include(p => p.Beneficiary)
            .FirstOrDefaultAsync(m => m.BeneficiaryID == id);
            // if (validationFormToUpdate == null)
            // {
            //     return NotFound();
            // }
            if (await TryUpdateModelAsync<Validationform>(
                validationFormToUpdate,
                "validationform",
                i => i.AssessmentID, i => i.Indigenous, i => i.Pantawid, i => i.ReferenceCode, i => i.Beneficiary
            ))
            {

                
                if (FileUpload.GisPdf != null)
                {
                    // Delete the existing PDF file, if it exists
                    if (validationFormToUpdate.ReferenceCode != 0)
                    {
                        string fileNameToDelete = validationFormToUpdate.ReferenceCode.ToString() + ".pdf";
                        string existingFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Validationforms", fileNameToDelete);
                        if (System.IO.File.Exists(existingFilePath))
                        {
                            System.IO.File.Delete(existingFilePath);
                        }
                    }

                    // Generate a random number for the PDF filename
                    int referenceCode = GenerateReferenceCode(); // Assuming this function generates a random number
                    string pdfFileName = referenceCode.ToString() + ".pdf";

                    // Save the PDF file with the generated filename
                    await UploadPdf(pdfFileName, FileUpload.GisPdf);

                    // Update the reference code in your model
                    validationFormToUpdate.ReferenceCode = referenceCode;

                    
                }


                //   // Compare original and updated beneficiary objects to detect changes
                // var originalBeneficiary = JsonConvert.DeserializeObject<Beneficiary>(JsonConvert.SerializeObject(validationFormToUpdate.Beneficiary));
                // var changes = new List<string>();
                // // Compare specific properties for changes
                // if (originalBeneficiary.LastName != validationFormToUpdate.Beneficiary.LastName)
                // {
                //     changes.Add($"Last Name: {originalBeneficiary.LastName} => {validationFormToUpdate.Beneficiary.LastName}");
                // }
                // if (originalBeneficiary.FirstName != validationFormToUpdate.Beneficiary.FirstName)
                // {
                //     changes.Add($"First Name: {originalBeneficiary.FirstName} => {validationFormToUpdate.Beneficiary.FirstName}");
                // }

                // if (originalBeneficiary.MiddleName != validationFormToUpdate.Beneficiary.MiddleName)
                // {
                //     changes.Add($"Middle Name: {originalBeneficiary.MiddleName} => {validationFormToUpdate.Beneficiary.MiddleName}");
                // }

                // if (originalBeneficiary.ExtName != validationFormToUpdate.Beneficiary.ExtName)
                // {
                //     changes.Add($"Ext Name: {originalBeneficiary.ExtName} => {validationFormToUpdate.Beneficiary.ExtName}");
                // }

                // if (changes.Any())
                // {
                //     // Create a new Log entity
                //     var log = new Log
                //     {
                //         BeneficiaryID = validationFormToUpdate.BeneficiaryID,
                //         // Message = $"Beneficiary details updated. Changes: {string.Join(", ", changes)}",
                //         Message = $"{string.Join(", ", changes)}",
                //         LogType = 0, // Assuming 1 represents an update
                //         User = "Current user", // Set the user who made the changes
                //         DateTimeEntry = DateTime.Now // Set the current date and time
                //     };

                //     // Add the Log entity to the DbContext
                //     _context.Logs.Add(log);
                // }
               
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        
        private async Task UploadPdf(string fileName, IFormFile file)
        {
            // Save the PDF file with the given filename
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Validationforms");
            string filePath = Path.Combine(serverFolder, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }

        }


    }
}
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

                // if (!int.IsNullOrEmpty(validationFormToUpdate.ReferenceCode))
                // {
                //     var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "pdf/Validationforms");

                //     // Retry logic with delay
                //     const int maxRetries = 3;
                //     const int delayMs = 1000;
                //     int retries = 0;

                //     while (retries < maxRetries)
                //     {
                //         try
                //         {
                //             // Attempt to delete the file
                //             if (System.IO.File.Exists(filePath))
                //             {
                //                 System.IO.File.Delete(filePath);
                //                 break; // If deletion succeeds, exit the loop
                //             }
                //         }
                //         catch (IOException ex)
                //         {
                //             // Handle file in use exception
                //             Console.WriteLine($"Failed to delete file: {ex.Message}");
                //             retries++;
                //             Thread.Sleep(delayMs); // Wait before retrying
                //         }
                //     }
                // }


                //  _context.Validationforms.Add(file);
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
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
        // private async Task<string> UploadImage(string folderPath, IFormFile file)
        // {
        //     string year = DateTime.Now.Year.ToString();
        //     string month = DateTime.Now.Month.ToString().PadLeft(2, '0'); // Ensure two digits
        //     string day = DateTime.Now.Day.ToString().PadLeft(2, '0'); // Ensure two digits
        //     string randomNumbers = GenerateRandomNumbers(4); // Function to generate four random numbers

        //     //folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;
        //     folderPath += $"{year}{month}{day}{randomNumbers}.pdf";

        //     string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

        //     await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        //     return "/" + folderPath;
        // }
        // private async Task<string> UploadImage(int referenceCode, IFormFile file)
        // {
        //     string year = DateTime.Now.Year.ToString();
        //     string month = DateTime.Now.Month.ToString().PadLeft(2, '0');
        //     string day = DateTime.Now.Day.ToString().PadLeft(2, '0');
        //     string randomNumbers = GenerateRandomNumbers(4);

        //     string folderPath = $"pdf/Validationforms/{year}{month}{day}{randomNumbers}_{referenceCode}.pdf";
        //     string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

        //     using (var fileStream = new FileStream(serverFolder, FileMode.Create))
        //     {
        //         await file.CopyToAsync(fileStream);
        //     }

        //     return "/" + folderPath;
        // }

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
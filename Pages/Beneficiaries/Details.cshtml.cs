using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using SpinsOnlineRazor.Models.RedesignModels.ComplexModels;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class DetailsModel : PageModel
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly SpinsOnlineRazor.Data.SpinsContext _context;

        public DetailsModel(SpinsOnlineRazor.Data.SpinsContext context)
        {
            _context = context;
        }
        

    public Validationform validationform { get; set; }
        public Beneficiary Beneficiary { get; set; }


        // public async Task<IActionResult> AddNewValidation(Validationform validationformModel)
        // {
        //     if (ModelState.IsValid)
        //     {

        //         if (validationformModel.BookPdf != null)
        //         {

        //             string folder = "wwwroot/pdf/";
        //             validationformModel.ReferenceCode = await UploadImage(folder, validationformModel.BookPdf);
        //         }

        //         if (await TryUpdateModelAsync<Validationform>(validationformModel, "Validationform", s => s.ReferenceCode))
        //         {
        //             _context.Validationforms.Add(validationformModel);
        //             await _context.SaveChangesAsync();
        //             return RedirectToPage("./Index");
        //         }



        //     }
        //           return Page();


        // }

        // private async Task<int> UploadImage(string folderPath, IFormFile file)
        // {

        //     folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

        //     string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

        //     await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

        //     return "/" + folderPath;
        // }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            /*Beneficiary = await _context.Beneficiaries
            .Include(s => s.Masterlists)
            .ThenInclude(r => r.Region)
             .ThenInclude(p => p.Provinces)
              .ThenInclude(m => m.Municipalities)
               .ThenInclude(r => r.Barangays)
            .AsNoTracking()
            .FirstOrDefaultAsync(m => m.ID == id);*/

            //Code na mag pa show instead of Region, Province, Municipality, and Barangay codes and e show ila name an e show.
            Beneficiary = await _context.Beneficiaries
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Region)
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Province)
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Municipality)
        .Include(b => b.Masterlists)
            .ThenInclude(m => m.Barangay)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Sex)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Maritalstatus)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Validationform)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.Validationform.Assessment)
        .Include(b => b.Masterlists)
            .ThenInclude(s => s.IdentificationType)
        .Include(h => h.HealthStatus)
        .AsNoTracking()
        .FirstOrDefaultAsync(m => m.BeneficiaryID == id);


            if (Beneficiary == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

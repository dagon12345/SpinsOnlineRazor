using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models;

namespace SpinsOnlineRazor.Pages.Masterlists
{
    public class EditModel : PageModel
    {
        private readonly SpinsOnlineRazor.Data.SchoolContext _context;

        public EditModel(SpinsOnlineRazor.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Masterlist Masterlist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var masterlist =  await _context.Masterlist.FirstOrDefaultAsync(m => m.ID == id);
            if (masterlist == null)
            {
                return NotFound();
            }
            Masterlist = masterlist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Masterlist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterlistExists(Masterlist.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MasterlistExists(int id)
        {
            return _context.Masterlist.Any(e => e.ID == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;

namespace SpinsOnlineRazor.Models.RedesignModels.Dropdowns
{
    /*The preceding code creates a SelectList to contain the list of department names. 
    If selectedDepartment is specified, that department is selected in the SelectList.*/
    public class IdentificationTypeNamePageModel : PageModel
    {
        public SelectList IdentificationNameSL { get; set; }
        public void PopulateIndetificationDropDownList(SpinsContext _context, object selectedIdtype = null)
        {
            var identificationsQuery = from d in _context.IdentificationTypes
                                       orderby d.Name // Sort by Name
                                       select d;

            IdentificationNameSL = new SelectList(identificationsQuery.AsNoTracking(),
                nameof(IdentificationType.IdentificationTypeID),
                nameof(IdentificationType.Name),
                selectedIdtype);
        }
    }
}
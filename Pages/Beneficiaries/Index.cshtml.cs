using System.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Data;
using SpinsOnlineRazor.Models.RedesignModels;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
  public class IndexModel : PageModel
  {
    /*Requires adding using System;.
Adds properties to contain the sorting parameters.
Changes the name of the Beneficiary property to Beneficiaries.
Replaces the code in the OnGetAsync method.*/
    private readonly SpinsContext _context;
    private readonly IConfiguration Configuration;
    public IndexModel(SpinsContext context, IConfiguration configuration)
    {
      _context = context;
      Configuration = configuration;
    }
    //Sorting sa ubos.
    public string NameSort { get; set; }
    //public string DateSort { get; set; }
    public string CurrentFilter { get; set; }

    public string CurrentSort { get; set; }

    /*Changes the type of the Students property from IList<Student> to PaginatedList<Student>.
Adds the page index, the current sortOrder, and the currentFilter to the OnGetAsync method signature.
Saves the sort order in the CurrentSort property.
Resets page index to 1 when there's a new search string.
Uses the PaginatedList class to get Student entities.
Sets pageSize to 2 from Configuration, 3 if configuration fails.*/

    public PaginatedList<Beneficiary> Beneficiaries { get; set; }
    /*The OnGetAsync method receives a sortOrder parameter from the query string in the URL.
     The URL and query string is generated by the Anchor Tag Helper.*/

    public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, int? pageIndex)
    {



      /*When the Index page is requested from the Students link, there's no query string. 
      The students are displayed in ascending order by last name. 
      Ascending order by last name is the default in the switch statement.
       When the user clicks a column heading link, the appropriate sortOrder value is provided in the query string value.*/

      /*The method uses LINQ to Entities to specify the column to sort by. 
      The code initializes an IQueryable<Student> before the switch statement, 
      and modifies it in the switch statement:*/

      /*The CurrentSort property provides the Razor Page with the current sort order.
       The current sort order must be included in the paging links to keep the sort order while paging.*/
      CurrentSort = sortOrder;
      //using System;
      NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
      //DateSort = sortOrder == "Date" ? "date_desc" : "Date";
      if (searchString != null)
      {
        /*If the search string is changed while paging, the page is reset to 1.
         The page has to be reset to 1 because the new filter can result in different data to display.
          When a search value is entered and Submit is selected:*/
        pageIndex = 1;
      }
      else
      {
        searchString = currentFilter;
      }
      /*The CurrentFilter property provides the Razor Page with the current filter string. The CurrentFilter value:

Must be included in the paging links in order to maintain the filter settings during paging.
Must be restored to the text box when the page is redisplayed.*/
      CurrentFilter = searchString;
      /*When an IQueryable is created or modified, no query is sent to the database. 
      The query isn't executed until the IQueryable object is converted into a collection. 
      IQueryable are converted to a collection by calling a method such as ToListAsync. 
      Therefore, the IQueryable code results in a single query that's not executed until the following statement:
       Beneficiaries = await beneficiariesIQ.AsNoTracking().ToListAsync();*/
      IQueryable<Beneficiary> beneficiariesIQ = from s in _context.Beneficiaries select s;
      /*Adds the searchString parameter to the OnGetAsync method, 
      and saves the parameter value in the CurrentFilter property.
       The search string value is received from a text box that's added in the next section.
Adds to the LINQ statement a Where clause. 
The Where clause selects only beneficiaries whose LastName or FirstName or LastName and FirstName and MiddleName contains the search string. 
The LINQ statement is executed only if there's a value to search for.*/
      if (!String.IsNullOrEmpty(searchString))
      {
        /*SQL Server defaults to case-insensitive. SQLite defaults to case-sensitive.Kung Sql server dili case sensitive
        Kung SQLite ato gamiton kay case sensitive need nat mag add nan .ToUpper()
        example nan ini kay ini:
        s.FirstName.Contains(searchString.ToUpper())
        Pero jauy performance penalty and .ToUpper().The ToUpper code adds a function in the WHERE clause of the TSQL SELECT statement. 
        The added function prevents the optimizer from using an index. 
        Given that SQL is installed as case-insensitive, it's best to avoid the ToUpper call when it's not needed*/
        beneficiariesIQ = beneficiariesIQ.Where(s => s.LastName.Contains(searchString) || s.FirstName.Contains(searchString)
        || s.MiddleName.Contains(searchString) || s.LastName.Contains(searchString) && s.FirstName.Contains(searchString) && s.MiddleName.Contains(searchString));
      }
      switch (sortOrder)
      {
        case "name_desc":
          beneficiariesIQ = beneficiariesIQ.OrderByDescending(s => s.LastName);
          break;
        /* case "Date":
             beneficiariesIQ = beneficiariesIQ.OrderBy(s => s.BirthDate);
             break;
         case "date_desc":
             beneficiariesIQ = beneficiariesIQ.OrderByDescending(s => s.BirthDate);
             break;
             */
        default:
          beneficiariesIQ = beneficiariesIQ.OrderBy(s => s.LastName);
          break;

      }


      // Para sa pagination nanpage. The expression pageIndex ?? 1 returns the value of pageIndex if it has a value, otherwise, it returns 1.
       var pageSize = Configuration.GetValue("PageSize", 3);
       Beneficiaries = await PaginatedList<Beneficiary>.CreateAsync(
           beneficiariesIQ
           .Include(s => s.Masterlists)
             .ThenInclude(r => r.Region)
           .Include(s => s.Masterlists)
             .ThenInclude(p => p.Province)
           .Include(s => s.Masterlists)
             .ThenInclude(m => m.Municipality)
           .Include(s => s.Masterlists)
             .ThenInclude(b => b.Barangay)
           .Include(s => s.Masterlists)
             .ThenInclude(st => st.Status)
           .Include(s => s.Masterlists)
             .ThenInclude(i => i.IdentificationType)
           //.ThenInclude(v => v.Validationform.Assessment)
           .AsNoTracking(), pageIndex ?? 1, pageSize);



      


    }
  }
}

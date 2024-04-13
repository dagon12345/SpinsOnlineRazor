using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SpinsOnlineRazor
{
    public class PaginatedList<T> : List<T>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(items);
        }
        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;
        /*The CreateAsync method in the preceding code takes page size and page number and applies
         the appropriate Skip and Take statements to the IQueryable. 
         When ToListAsync is called on the IQueryable, 
         it returns a List containing only the requested page. 
         The properties HasPreviousPage and HasNextPage are used to enable or disable Previous and Next paging buttons.

        The CreateAsync method is used to create the PaginatedList<T>. 
        A constructor can't create the PaginatedList<T> object; constructors can't run asynchronous code.*/

        //Para ma edit an pagination list jaun didto naka locate sa appsettings.json: "PageSize":2,
        public static async Task<PaginatedList<T>> CreateAsync(
            IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip(
                (pageIndex - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return new PaginatedList<T>(items, count, pageIndex, pageSize);
        }


    }
}
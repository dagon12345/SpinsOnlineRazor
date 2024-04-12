using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpinsOnlineRazor.Models;

namespace SpinsOnlineRazor.Data
{
    public class SchoolContext : DbContext
    {
        public SchoolContext (DbContextOptions<SchoolContext> options)
            : base(options)
        {
        }

        public DbSet<SpinsOnlineRazor.Models.Masterlist> Masterlist { get; set; } = default!;
    }
}

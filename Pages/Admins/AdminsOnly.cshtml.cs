using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SpinsOnlineRazor.Pages.Admins
{
    public class AdminsOnly : PageModel
    {
        private readonly ILogger<AdminsOnly> _logger;

        public AdminsOnly(ILogger<AdminsOnly> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
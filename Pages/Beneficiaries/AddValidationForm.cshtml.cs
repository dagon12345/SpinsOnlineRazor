using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace SpinsOnlineRazor.Pages.Beneficiaries
{
    public class AddValidationForm : PageModel
    {
        private readonly ILogger<AddValidationForm> _logger;

        public AddValidationForm(ILogger<AddValidationForm> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
        }
    }
}
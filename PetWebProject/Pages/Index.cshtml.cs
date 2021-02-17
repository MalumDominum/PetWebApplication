using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFDataAccessLibrary;
using EFDataAccessLibrary.Models;

namespace PetWebProject.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly PetContext _db;

        public IndexModel(ILogger<IndexModel> logger, PetContext db)
        {
            _logger = logger;
            _db = db;
        }

        public void OnGet()
        {
            
        }
    }
}

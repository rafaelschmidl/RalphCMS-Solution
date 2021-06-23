using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RalphCMS.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public IndexModel(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public new Models.Page Page { get; set; }

        public void OnGet()
        {
            Page = _context.Pages.FirstOrDefault(p => p.Title == "Index");
        }
    }
}

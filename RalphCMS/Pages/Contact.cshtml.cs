using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RalphCMS.Pages
{

    public class ContactModel : PageModel
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public ContactModel(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public new Models.Page Page { get; set; }

        public void OnGet()
        {
            Page = _context.Pages.FirstOrDefault(p => p.Title == "Contact");

        }
    }
}

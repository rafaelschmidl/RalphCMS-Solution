using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RalphCMS.Data;
using RalphCMS.Models;

namespace RalphCMS.Pages.Admin
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public DeleteModel(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Models.Page Page { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Page = await _context.Pages.FirstOrDefaultAsync(m => m.Title == id);

            if (Page == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Page = await _context.Pages.FindAsync(id);

            if (Page != null)
            {
                _context.Pages.Remove(Page);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

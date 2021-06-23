using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RalphCMS.Data;
using RalphCMS.Models;

namespace RalphCMS.Pages.Admin
{
    [Authorize]
    public class EditModel : PageModel
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public EditModel(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public new Models.Page Page { get; set; }

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

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Page).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PageExists(Page.Title))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PageExists(string id)
        {
            return _context.Pages.Any(e => e.Title == id);
        }
    }
}

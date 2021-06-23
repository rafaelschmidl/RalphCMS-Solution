using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RalphCMS.Data;
using RalphCMS.Models;

namespace RalphCMS.Pages.Admin
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public CreateModel(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;

        }

        [BindProperty]
        public new Models.Page Page { get; set; }

        public List<string> PageTitles { get; set; }
        private readonly List<string> pageTitles = new List<string>() { "About", "Contact", "Road Map" };

        public IActionResult OnGet()
        {

            var usedPageTitles = _context.Pages.Select(p => p.Title).ToList();
            var unusedPageTitles = pageTitles.Where(pt => !usedPageTitles.Contains(pt)).ToList();

            PageTitles = unusedPageTitles;

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

            Page.Index = _context.Pages.Count();

            _context.Pages.Add(Page);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

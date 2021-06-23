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
    public class IndexModel : PageModel
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public IndexModel(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet = true)]
        public new IList<Models.Page> Page { get;set; }

        public async Task OnGetAsync()
        {
            Page = await _context.Pages.OrderBy(p => p.Index).ToListAsync();
        }

        public IActionResult OnPostToggleIsInNavMenu(int index)
        {
            var q = _context.Pages.FirstOrDefault(p => p.Index == index);
            q.IsInNavMenu = !q.IsInNavMenu;

            _context.SaveChanges();

            return RedirectToPage();
        }

        public IActionResult OnPostPageSectionUpButton(int index)
        {
            if (!ModelState.IsValid)
                return Page();

            SwapPageSectionsIndex(index, index -= 1);

            return RedirectToPage();
        }

        public IActionResult OnPostPageSectionDownButton(int index)
        {
            if (!ModelState.IsValid)
                return Page();

            SwapPageSectionsIndex(index, index += 1);

            return RedirectToPage();
        }

        private void SwapPageSectionsIndex(int index_1, int index_2)
        {
            var ps_1 = _context.Pages.FirstOrDefault(ps => ps.Index == index_1);
            var ps_2 = _context.Pages.FirstOrDefault(ps => ps.Index == index_2);

            if (ps_1 != null && ps_2 != null)
            {
                int temp = ps_1.Index;
                ps_1.Index = ps_2.Index;
                ps_2.Index = temp;

                _context.SaveChanges();
            }
        }
    }
}

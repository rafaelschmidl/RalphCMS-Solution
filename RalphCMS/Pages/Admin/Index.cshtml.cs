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

        public new IList<Models.Page> Page { get;set; }

        public async Task OnGetAsync()
        {
            Page = await _context.Pages.OrderBy(p => p.Index).ToListAsync();
        }
    }
}

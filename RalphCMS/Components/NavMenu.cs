using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RalphCMS.Components
{
    public class NavMenu : ViewComponent
    {
        private readonly RalphCMS.Data.ApplicationDbContext _context;

        public NavMenu(RalphCMS.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var navMenuItems = _context.Pages.OrderBy(p => p.Index).Select(p => p.Title).ToList();

            return View(navMenuItems);
        }
    }
}

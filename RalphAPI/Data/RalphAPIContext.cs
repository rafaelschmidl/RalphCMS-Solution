using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RalphAPI.Models;

namespace RalphAPI.Data
{
    public class RalphAPIContext : DbContext
    {
        public RalphAPIContext (DbContextOptions<RalphAPIContext> options)
            : base(options)
        {
        }

        public DbSet<RalphAPI.Models.Page> Pages { get; set; }
    }
}

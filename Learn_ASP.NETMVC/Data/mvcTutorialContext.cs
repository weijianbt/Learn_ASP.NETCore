using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvcTutorial.Models;

namespace mvcTutorial.Data
{
    public class mvcTutorialContext : DbContext
    {
        public mvcTutorialContext (DbContextOptions<mvcTutorialContext> options)
            : base(options)
        {
        }

        public DbSet<mvcTutorial.Models.Movie> Movie { get; set; } = default!;
    }
}

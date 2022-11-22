using IMDBApplication.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IMDBApplication.Models
{
    public class MoviesDBContext: DbContext
    {
        public MoviesDBContext(DbContextOptions<MoviesDBContext> options ):base(options)
        {

        }

        public DbSet<Movies> movies { get; set; }
        public DbSet<Actor> actors { get; set; }
        public DbSet<Producer> producer { get; set; }
    }
}

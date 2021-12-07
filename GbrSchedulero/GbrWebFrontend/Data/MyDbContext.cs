using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class MyDbContext: DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options): base(options)
        {

        }
        public MyDbContext()
        {

        }
        public DbSet<Crewmem> crewmems { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
       // {
          //  base.OnConfiguring(optionsBuilder);
           // ModelBuilder.Entity<Crewmem>
        //}
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer("A FALLBACK CONNECTION STRING");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }*/

    }
}

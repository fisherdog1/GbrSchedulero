using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class CrewMemsContext : DbContext 
    {
        public CrewMemsContext(DbContextOptions<CrewMemsContext> options): base(options)
        {

        }
        public DbSet<CrewmembersData> crewmembersDatas { get; set; }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost;user id=root;database=crewmems;persistsecurityinfo=True;");
            base.OnConfiguring(optionsBuilder);
        }*/
    }
}

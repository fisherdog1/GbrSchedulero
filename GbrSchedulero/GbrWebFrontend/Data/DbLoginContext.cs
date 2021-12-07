using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CHA.Data
{
    public class DbLoginContext: DbContext
    {
        
        public DbLoginContext(DbContextOptions<DbLoginContext> options) : base(options)
        {

        }
        public DbLoginContext()
        {

        }
        public DbSet<LoginData> loginDatas { get; set; }
    }
}

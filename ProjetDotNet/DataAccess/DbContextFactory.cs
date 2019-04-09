using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDotNet.DataAccess
{
    class DbContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
       
        public DbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();
            optionsBuilder.UseSqlite("Data Source=database.db");

            return new DbContext(optionsBuilder.Options);
        }
        
    }
}

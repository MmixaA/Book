using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data.DesignFactory
{
    public class BookDbContextFactory : IDesignTimeDbContextFactory<BookDBContext>
    {
        public BookDBContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookDBContext>();
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=Books;Trusted_Connection=True;MultipleActiveResultSets=true");

            return new BookDBContext(optionsBuilder.Options);
        }
    }

}

using Data.Data;
using Data.Entities;
using Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        private readonly BookDBContext bookDBContext;

        public BookRepository(BookDBContext dbContext) : base(dbContext)
        {
            bookDBContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllWithDetailsAsync()
        {
            return await bookDBContext.Books.Include(p => p.Authors).ToListAsync();
        }

        public async Task<Book> GetByIdWithDetailsAsync(int id)
        {
            return await bookDBContext.Books.Include(p => p.Authors).FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}

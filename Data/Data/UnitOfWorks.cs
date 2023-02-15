using Data.Entities;
using Data.Interfaces;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BookDBContext bookDBContext;
        private IBookRepository books;
        private IRepository<Author> authors;
        public UnitOfWork(BookDBContext bookDBContext)
        {
            this.bookDBContext = bookDBContext;
            books = new BookRepository(bookDBContext);
            authors = new Repository<Author>(bookDBContext);
        }
        public IBookRepository BookRepository => books;
        public IRepository<Author> AuthorRepository => authors;

        public async Task SaveAsync()
        {
            await bookDBContext.SaveChangesAsync();
        }
    }
}

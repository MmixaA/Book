using Book.UI.Models;

namespace Book.UI.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAll();
        Task<BookModel> GetByID(int id);
        Task<IEnumerable<BookModel>> Filter(string searchitem);
        Task DeleteByID(int id);
        Task EditByID(int id, BookModel bookModel);
        Task Create(BookModel bookModel);
    }
}

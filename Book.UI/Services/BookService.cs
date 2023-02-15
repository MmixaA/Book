using Book.UI.Helper;
using Book.UI.Models;
using Book.UI.Services.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Book.UI.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient client;

        public BookService(HttpClient client)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
        }
        public async Task<IEnumerable<BookModel>> GetAll()
        {
            var response = await client.GetAsync("/api/Book");

            return await response.ReadContentAsync<List<BookModel>>();
        }

        public async Task<BookModel> GetByID(int id)
        {
            var response = await client.GetAsync($"/api/Book/{id}");

            return await response.ReadContentAsync<BookModel>();
        }

        public async Task<IEnumerable<BookModel>> Filter(string searchitem)
        {
            var response = await client.GetAsync($"/api/books/search/{searchitem}");

            return await response.ReadContentAsync<List<BookModel>>();
        }
        public async Task DeleteByID(int id)
        {
            var response = await client.DeleteAsync($"/api/Book/{id}");
        }
        public async Task EditByID(int id, BookModel bookModel)
        {
            string json = JsonConvert.SerializeObject(bookModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PutAsync($"/api/Book/{id}", content);
        }
        public async Task Create(BookModel bookModel)
        {
            string json = JsonConvert.SerializeObject(bookModel);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"/api/Book/", content);
        }


    }
}

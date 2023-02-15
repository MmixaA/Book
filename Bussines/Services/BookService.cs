using AutoMapper;
using Bussines.Interfaces;
using Bussines.Model;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussines.Services
{
    public class BookService : IBookService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public BookService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task AddAsync(BookCreateModel model)
        {
            if (model == null)
            {
                throw new Exception();
            }

            var book = mapper.Map<Book>(model);

            await unitOfWork.BookRepository.AddAsync(book);
            await unitOfWork.SaveAsync();       
        }

        public async Task DeleteAsync(int modelId)
        {
            var book = unitOfWork.BookRepository.GetByIdAsync(modelId);

            if (book == null)
            {
                throw new Exception();
            }

            await unitOfWork.BookRepository.DeleteByIdAsync(modelId);
            await unitOfWork.SaveAsync();
        }

        public async Task<IEnumerable<BookDTO>> GetAllAsync()
        {
            var books = await unitOfWork.BookRepository.GetAllWithDetailsAsync();
            return books.Select(b => mapper.Map<BookDTO>(b));
        }

        public async Task<IEnumerable<BookDTO>> GetByFilterAsync(string searchitem)
        {
            var books = await GetAllAsync();
            var result = books.Where(b => b.Title.Contains(searchitem) || b.Authors.Select(a => a.Name).Contains(searchitem));

            return result.Select(b => mapper.Map<BookDTO>(b));
        }

        public async Task<BookDTO> GetByIdAsync(int id)
        {
            return mapper.Map<BookDTO>(await unitOfWork.BookRepository.GetByIdWithDetailsAsync(id));
        }

        public async Task UpdateAsync(BookDTO model)
        {
            var book = mapper.Map<Book>(model);

            unitOfWork.BookRepository.Update(book);

            await unitOfWork.SaveAsync();
        }
    }
}

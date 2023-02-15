using Book.UI.Models;
using Book.UI.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Book.UI.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookService service;

        public BooksController(IBookService service)
        {
            this.service = service ?? throw new ArgumentNullException(nameof(service));
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await service.GetAll();
            return View(books);
        }

        // GET: Books
        public async Task<IActionResult> ShowSearchResult(string SearchPhrase)
        {
            var books = await service.Filter(SearchPhrase);
            return View("Index", books);
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var book = await service.GetByID(id);
            return View(book);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View(new BookModel());
        }

        // POST: Books/Create
        // To protect from overposting attac
        [HttpPost]
        public async Task<IActionResult> Create( BookModel book)
        {
            var authors = new List<AuthorModel>();

            //Loop through the forms
            for (int i = 0; i < Request.Form.Count; i++)
            {
                var name = Request.Form["Name[" + i + "]"];
                var surname = Request.Form["Surname[" + i + "]"];
                var parseBirthDate = Request.Form["BirthDate[" + i + "]"];

                DateTime birthDate;

                if(!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(surname) && DateTime.TryParse(parseBirthDate,out birthDate))
                {
                    authors.Add(new AuthorModel { Name = name, Surname = surname, BirthDate = birthDate });
                }
            }

            book.Authors = authors;
            await service.Create(book);

            return RedirectToAction("Index");
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var book = await service.GetByID(id);
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, BookModel book)
        {
            await service.EditByID(id, book);

            return RedirectToAction(nameof(Index));
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var book = await service.GetByID(id);
            return View(book);
        }

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await service.DeleteByID(id);
            return RedirectToAction(nameof(Index));
        }
        public ActionResult AuthorEditor(int index)
        {
            return PartialView("_AuthorEditor", new AuthorModel { BookId = 0, ID = 0, Name = "", Surname = "", BirthDate = DateTime.Now });
        }

    }
}

using Bussines.Interfaces;
using Bussines.Model;
using Bussines.Services;
using Data.Data;
namespace Book.API.Controllers
{
    public static class BookEndpoints
    {
            public static void MapBookEndpoints (this IEndpointRouteBuilder routes)
            {
                routes.MapGet("/api/Book", async (IBookService bookService) =>
                {
                    return await bookService.GetAllAsync();
                })
                .WithName("GetAllBooks");

                routes.MapGet("/api/Book/{id}", async (int id, IBookService bookService) =>
                {
                    return await bookService.GetByIdAsync(id)
                        is BookDTO model
                            ? Results.Ok(model)
                            : Results.NotFound();
                })
                .WithName("GetBookById");

            routes.MapGet("/api/books/search/{searchitem}", async (string searchitem, IBookService bookService) =>
            {
                return await bookService.GetByFilterAsync(searchitem);
            })
            .WithName("GetByFilter");

            routes.MapPut("/api/Book/{id}", async (int id, BookDTO book, IBookService bookService) =>
                {
                    if (book is null)
                    {
                        return Results.NotFound();
                    }

                    try 
                    {
                        await bookService.UpdateAsync(book);
                    }
                    catch(Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    

                    return Results.NoContent();
                })   
                .WithName("UpdateBook");

                routes.MapPost("/api/Book/", async (BookCreateModel book, IBookService bookService) =>
                {
                    await bookService.AddAsync(book);
                    return Results.Created($"/Books/", book);
                })
                .WithName("CreateBook");


                routes.MapDelete("/api/Book/{id}", async (int id, IBookService bookService) =>
                {
                    if (await bookService.GetByIdAsync(id) is BookDTO book)
                    {
                        await bookService.DeleteAsync(id);
                        return Results.Ok(book);
                    }

                    return Results.NotFound();
                })
                .WithName("DeleteBook");
        }
    }
}

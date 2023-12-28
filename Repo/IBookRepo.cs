using BookStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Repo
{
    public interface IBookRepo
    {

        Task<List<BookModel>> GetBooks();
        Task<BookModel> GetBookById(int BookId);

        Task AddBook(BookModel bookModel);
        Task UpdateBook(int id, BookModel bookModel);

        Task UpdateBookPatch(int id, JsonPatchDocument model);
        Task Delete(int id);
    }
}

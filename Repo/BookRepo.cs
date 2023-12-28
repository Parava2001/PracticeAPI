using AutoMapper;
using BookStore.EF_Core;
using BookStore.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repo
{
    public class BookRepo : IBookRepo
    {
        private readonly EF_DataContext context;  // DI from the 
        private  readonly IMapper mapper;

    
        public BookRepo(EF_DataContext context )
        {
            this.context = context;
       
        }

        public BookRepo(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public async Task<List<BookModel>> GetBooks()
        {
          //  var records = await context.Books.Select(x => new BookModel()
           // {
           //     Id = x.Id,
           //     Title = x.Title,
           //     Description = x.Description,

          //  }).ToListAsync();
           // return records;

             var records = await context.Books.ToListAsync();
             return mapper.Map<List<BookModel>>(records);       // Automapper
        }

        public async Task<BookModel> GetBookById(int BookId)
        {
           // var record = await context.Books.Where(d => d.Id.Equals(BookId)).FirstOrDefaultAsync();
            // or 
            // var record = await contxt.Books.FindAsync(BookId);
          // return new BookModel()
            //{
            //    Id = record.Id,
             //   Title = record.Title,
             //   Description = record.Description
           // };

            var records = await context.Books.FindAsync(BookId);
            return mapper.Map<BookModel>(records);

        }

        public async Task AddBook(BookModel bookModel)
        {
            var book = new Books()
            {
                Title = bookModel.Title,
               Description = bookModel.Description
            };

           context.Books.Add(book);
            await context.SaveChangesAsync();
        }




        public async Task UpdateBook(int id ,  BookModel bookModel)
        {
            var check = await context.Books.FindAsync(id);  // In here we are hitting the Db twice in this line 
            if (check != null)
            {
              //  check.Title = bookModel.Title;
              //  check.Description = bookModel.Description;
                mapper.Map<BookModel>(check);        // using Automapper
                await context.SaveChangesAsync();    // second time hiting Db
             
            }
        }
         
        public async Task UpdateBookPatch(int id , JsonPatchDocument model)
        {
            var UpdateCheck = await context.Books.FindAsync(id);
            if(UpdateCheck != null)
            {
                model.ApplyTo(UpdateCheck); // ApplyTo() is a function used for patching in JsonPatchDocument
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var DeleteBooks = await context.Books.Where(d => d.Id.Equals(id)).FirstOrDefaultAsync();
            if (DeleteBooks != null)
            {
                context.Books.Remove(DeleteBooks);
              await context.SaveChangesAsync();
              


            }

        }

   
    }
}

using BookStore.Models;
using BookStore.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepo bookRepo;

        public BooksController(IBookRepo bookRepo)
        {
            this.bookRepo = bookRepo;
        }


        [HttpGet]
        [Route("GetBooks")]

        public async Task<IActionResult> Get()
        {
            var data = await bookRepo.GetBooks();
            return Ok(data);
        }


        [HttpGet("{Id}")]

        public async Task<IActionResult> GetId([FromRoute]int Id)
        {
            var data = await bookRepo.GetBookById(Id);
            return Ok(data);    
        }

        [HttpPost("")]
        public async Task <IActionResult> PostBooks([FromBody]BookModel model)
        {
            await bookRepo.AddBook(model);
            return Ok();
        }

        [HttpPut("{id}")]   // update in all the properties in the model 
        public async Task<IActionResult> PatchBook([FromBody] BookModel model , [FromRoute] int id)
        {
           await bookRepo.UpdateBook(id, model);
            return Ok();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchUpdateBook([FromBody] JsonPatchDocument model , [FromRoute] int id)
        {
            await bookRepo.UpdateBookPatch(id, model);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveBook([FromRoute]int id)
        {
            await bookRepo.Delete(id);
            return Ok();
        }
    }


}

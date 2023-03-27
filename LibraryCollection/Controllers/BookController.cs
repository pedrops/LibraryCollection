using LibraryCollection.Domain.Abstractions.Service;
using LibraryCollection.Domain.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryCollection.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookService bookService;
        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet("Search")]
        public async Task<IEnumerable<BookDTO>> GetBooks(string field, string value)
        {
            return await bookService.GetBookListByField(field, value);
        }

        [HttpGet]
        public async Task<IEnumerable<BookDTO>> GetAllBooks()
        {
            var aaaa = await bookService.GetAllBookList();
            return aaaa;
        }


    }
}

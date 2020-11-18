using LibraryApp_WebAPI.Models;
using LibraryApp_WebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApp_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var people = BookRepository.GetBooks();
            return Ok(people);
        }

        [HttpPost]
        public ActionResult Post(Book book)
        {

            BookRepository.AddBook(book);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Book book, long id)
        {
            var dbperson = BookRepository.GetBook(id);
            if (dbperson != null)
            {
                BookRepository.UpdateBook(book);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var success = BookRepository.DeleteBook(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

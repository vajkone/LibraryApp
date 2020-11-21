using LibraryApp_Common.Models;
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
    public class LibraryBookController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<LibraryBook>> Get()
        {
            var libraryBook = LibraryBookRepository.GetLibraryBooks();
            return Ok(libraryBook);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(long id)
        {
            var lbook = LibraryBookRepository.GetLibraryBook(id);


            if (lbook != null)
            {
                return Ok(lbook);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public ActionResult Post(LibraryBook lbook)
        {

            LibraryBookRepository.AddLibraryBook(lbook);
            return Ok();
        }
    }
}

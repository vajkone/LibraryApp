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
    public class AuthorController : ControllerBase
    {

        [HttpGet]
        public ActionResult<IEnumerable<Author>> Get()
        {
            var people = AuthorRepository.GetAuthors();
            return Ok(people);
        }

        [HttpPost]
        public ActionResult Post(Author author)
        {

            AuthorRepository.AddAuthor(author);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(Author author, long id)
        {
            var dbAuthor = AuthorRepository.GetAuthor(id);
            if (dbAuthor != null)
            {
                AuthorRepository.UpdateAuthor(author);
                return Ok();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var success = AuthorRepository.DeleteAuthor(id);
            if (success)
            {
                return Ok();
            }
            return NotFound();
        }
    }
}

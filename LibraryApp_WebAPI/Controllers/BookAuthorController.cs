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
    public class BookAuthorController : ControllerBase
    {

        [HttpPost]
        public ActionResult Post(BookAuthor ba)
        {

            BookAuthorRepository.AddBookAuthorLink(ba);
            return Ok();
        }

       
    }
}

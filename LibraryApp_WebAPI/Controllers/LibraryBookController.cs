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



        [HttpGet("{id}")]
        public ActionResult<LibraryBook> Get(long id)
        {
            var lbook = LibraryBookRepository.GetLibraryBooks(id);


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

        [HttpPut("{invNum}")]
        public ActionResult Put(string invNum)
        {
            var libBook = LibraryBookRepository.GetLibraryBook(invNum);

            if (libBook!=null)
            {
                
                
                LibraryBookRepository.LendReturnLibraryBook(libBook);
                return Ok();
            }return NotFound();
            
        }

    }
}

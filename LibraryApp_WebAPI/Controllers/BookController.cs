﻿using LibraryApp_Common.Models;
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
            var books = BookRepository.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public ActionResult<Book> Get(long id)
        {
            var book = BookRepository.GetBook(id);


            if (book != null)
            {
                return Ok(book);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("byAuthor")]
        public ActionResult<IEnumerable<Book>> Get(string author)
        {

            //böngészőben get: http://localhost:5000/api/book/byAuthor?author=mark

            var books = BookRepository.GetBooksByAuthor(author);
            if (books != null)
            {
                return Ok(books);
            }
            else
            {
                return NotFound();
            }
            
        }

        [HttpGet("ofMember")]
        public ActionResult<IList<LoanBook>> GetBooksOfMember(long id)
        {
            var books = BookRepository.GetBooksOfMember(id);
            return Ok(books);
        }

        [HttpGet("byInvNum")]
        public ActionResult<Book> GetBookByInvNum(string invnum)
        {
            var book = BookRepository.GetBookByInvNum(invnum);
            return Ok(book);
        }

        [HttpGet("authorById")]
        public ActionResult<Author> GetBookAuthorById(long bookid)
        {
            var author = BookRepository.GetBookAuthorById(bookid);
            return Ok(author);
        }


        [HttpGet("byISBN")]
        public ActionResult<long> GetId(string isbn)
        {

            //böngészőben get: http://localhost:5000/api/book/byISBN?isbn=012012

            var bookId = BookRepository.GetBookIdByISBN(isbn);
            if (bookId != -1)
            {
                return Ok(bookId);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet("byTitle")]
        public ActionResult<IList<Book>> GetBooksByTitle(string title)
        {
            var books = BookRepository.GetBooksByTitle(title);
            return Ok(books);
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
            var dbBook = BookRepository.GetBook(id);
            if (dbBook != null)
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

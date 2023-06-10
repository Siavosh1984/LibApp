using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using LibApp.Models;
using System.Diagnostics;

namespace LibApp.Controllers
{
    public class BookDataController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/BookData/ListBooks

        [HttpGet]
        public IEnumerable<BookDto> ListBooks()
        {
            List<Book> Books = db.Books.ToList();
            List<BookDto> BookDtos = new List<BookDto>();

            Books.ForEach(a => BookDtos.Add(new BookDto()
            {
                BookID = a.BookID,
                BookName = a.BookName,
                author = a.author,
                ISBN = a.ISBN,   
                genre = a.genre


            })); ; ;

            return BookDtos;
        } 

        // GET: api/BookData/FindBook/5
        [ResponseType(typeof(Book))]
        [HttpGet]
        public IHttpActionResult FindBook(int id)
        {
            Book Book = db.Books.Find(id);
            BookDto BookDto = new BookDto()
            {

                BookID = Book.BookID,
                BookName = Book.BookName,
                author = Book.author,
                ISBN = Book.ISBN,
                genre = Book.genre


            };

            if (Book == null)
            {
                return NotFound();
            }

            return Ok(BookDto);
        }

        // POST: api/BookData/UpdateBook/5
        [ResponseType(typeof(void))]

        [HttpPost]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            Debug.WriteLine("I have reached the update animal method!");
            if (!ModelState.IsValid)
            {

                Debug.WriteLine("Model State is invalid");
                return BadRequest(ModelState);
            }

            if (id != book.BookID)
            { 

                Debug.WriteLine("ID mismatch");
                Debug.WriteLine("GET parameter" + id);
                Debug.WriteLine("POST parameter" + book.BookID);
                Debug.WriteLine("POST parameter" + book.BookName);
                Debug.WriteLine("POST parameter " + book.author);
                Debug.WriteLine("POST parameter" + book.ISBN);
                Debug.WriteLine("POST parameter " + book.genre);

                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    Debug.WriteLine("Book not found");
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }


            Debug.WriteLine("Non of the conditions triggered");
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/BookData/AddBook
        [ResponseType(typeof(Book))]
        [HttpPost]
        public IHttpActionResult AddBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = book.BookID }, book);
        }

        // DELETE: api/BookData/DeletBook/5
        [ResponseType(typeof(Book))]
        [HttpPost]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookID == id) > 0;
        }
    }
}
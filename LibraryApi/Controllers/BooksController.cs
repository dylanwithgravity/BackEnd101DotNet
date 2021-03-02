using LibraryApi.Domain;
using LibraryApi.Models.Books;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApi.Controllers
{
    public class BooksController : ControllerBase
    {
        private readonly LibraryDataContext _context;

        public BooksController(LibraryDataContext context)
        {
            _context = context;
        }

        [HttpGet("/books/{id:int}")] 
        public async Task<ActionResult> GetBookById(int id)
        {
            var book = await _context.Books
                 .Where(b => b.IsAvailable && b.Id == id)
                 .Select(b => new GetBookDetailsResponse
                 {
                     Id = b.Id,
                     Title = b.Title,
                     Author = b.Author,
                     Genre = b.Genre
                 })
                 .SingleOrDefaultAsync();

            if(book == null)
            {
                return NotFound(); // 404
            } else
            {
                return Ok(book);
            }
        }
    }
}

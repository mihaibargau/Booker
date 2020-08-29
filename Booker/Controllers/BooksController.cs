using Booker.Data;
using Booker.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Booker.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;
        public BooksController(BookDbContext context)
        {
            _context = context;
        }
        public IActionResult List()
        {
            ViewBag.Books = _context.Books.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Book book)
        {
            if (!ModelState.IsValid)
            {
                TempData["formValid"] = "Invalid input";
                return Redirect("Create");
            }
            Book dbBook = _context.Books.Where(b => b.Title.Equals(book.Title))
                .Where(b => b.Author.Equals(book.Author))
                .Where(b => b.Genre.Equals(book.Genre))
                .FirstOrDefault();
            if (dbBook != null)
            {
                TempData["formValid"] = "Same book already added";
                return Redirect("Create");
            }
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            TempData["message"] = "Book added successfully";
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            TempData["message"] = "Book deleted successfully";
            return RedirectToAction("List");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Book book = await _context.Books.FirstOrDefaultAsync(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);

        }
    }
}

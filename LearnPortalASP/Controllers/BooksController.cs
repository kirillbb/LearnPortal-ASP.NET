namespace LearnPortalASP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using LearnPortalASP.Data;
    using LearnPortalASP.BLL.DataServices;
    using LearnPortalASP.BLL.DTO;

    public class BooksController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly BookService _bookService;
        private readonly MaterialService _materialService;

        public BooksController(ApplicationContext context)
        {
            _context = context;
            _bookService = new BookService(_context);
            _materialService = new MaterialService(_context);
        }

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _bookService.GetAllAsync();

            return books != null ?
                        View(books) :
                        Problem("Entity set 'ApplicationContext.Courses'  is null.");
        }

        // GET: Books/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var course = await _bookService.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Author,PublicationDate,Pages,BookFormat,Title,CreatorUserName,Discriminator")] BookDTO book)
        {
            if (ModelState.IsValid)
            {
                await _bookService.CreateAsync(book);
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Author,PublicationDate,Pages,BookFormat,Title,CreatorUserName")] BookDTO book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _bookService.UpdateAsync(book);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _bookService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'ApplicationContext.Books'  is null.");
            }
            var book = await _bookService.GetAsync(id);
            if (book != null)
            {
                await _materialService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.Books.Any(e => e.Id == id);
        }
    }
}

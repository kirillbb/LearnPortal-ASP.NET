using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LearnPortalASP.Data;
using LearnPortalASP.BLL.DataServices;
using LearnPortalASP.BLL.DTO;

namespace LearnPortalASP.Controllers
{
    public class PublicationsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly PublicationService _publicationService;
        private readonly MaterialService _materialService;

        public PublicationsController(ApplicationContext context)
        {
            _context = context;
            _publicationService = new PublicationService(_context);
            _materialService = new MaterialService(_context);
        }

        // GET: Publications
        public async Task<IActionResult> Index()
        {
            var publications = await _publicationService.GetAllAsync();

            return publications != null ?
                View(publications) :
                Problem("Entity set 'ApplicationContext.Courses'  is null.");
        }

        // GET: Publications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Publications == null)
            {
                return NotFound();
            }

            var publication = await _publicationService.GetAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // GET: Publications/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Publications/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CreationDate,Source,Id,Title,CreatorUserName,Discriminator")] PublicationDTO publication)
        {
            if (ModelState.IsValid)
            {
                await _publicationService.CreateAsync(publication);
                return RedirectToAction(nameof(Index));
            }
            return View(publication);
        }

        // GET: Publications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Publications == null)
            {
                return NotFound();
            }

            var publication = await _publicationService.GetAsync(id);
            if (publication == null)
            {
                return NotFound();
            }
            return View(publication);
        }

        // POST: Publications/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CreationDate,Source,Id,Title,CreatorUserName,Discriminator")] PublicationDTO publication)
        {
            if (id != publication.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _publicationService.UpdateAsync(publication);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PublicationExists(publication.Id))
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
            return View(publication);
        }

        // GET: Publications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Publications == null)
            {
                return NotFound();
            }

            var publication = await _publicationService.GetAsync(id);
            if (publication == null)
            {
                return NotFound();
            }

            return View(publication);
        }

        // POST: Publications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Publications == null)
            {
                return Problem("Entity set 'ApplicationContext.Publications'  is null.");
            }
            var publication = await _publicationService.GetAsync(id);
            if (publication != null)
            {
                await _materialService.DeleteAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool PublicationExists(int id)
        {
          return _context.Publications.Any(e => e.Id == id);
        }
    }
}

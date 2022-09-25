namespace LearnPortalASP.Controllers
{
    using LearnPortalASP.BLL.DataServices;
    using Microsoft.AspNetCore.Mvc;
    using LearnPortalASP.Data;

    public class MaterialController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly MaterialService _materialService;

        public MaterialController(ApplicationContext context)
        {
            _context = context;
            this._materialService = new MaterialService(_context);
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var materials = await _materialService.GetAllAsync();

            return materials != null ?
                        View(materials) :
                        Problem("Entity set 'ApplicationContext.Materials'  is null.");
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Materials == null)
            {
                return NotFound();
            }

            var material = await _materialService.GetAsync(id);
            if (material == null)
            {
                return NotFound();
            }

            return View(material);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Materials'  is null.");
            }

            var material = await _materialService.GetAsync(id);
            if (material != null)
            {
                await _materialService.DeleteAsync(material.Id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return (_context.Materials?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

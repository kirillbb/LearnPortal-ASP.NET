using basicFunctions_DB.DAL;
using basicFunctions_DB.BLL.DataServices;
using Microsoft.AspNetCore.Mvc;
using basicFunctions_DB.BLL.DTO;

namespace LearnPortalASP.Controllers
{
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

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Discriminator,CreatorUserName")] MaterialDTO materialDTO)
        {
            if (ModelState.IsValid)
            {
                await _materialService.CreateAsync(materialDTO);
                return RedirectToAction(nameof(Index));
            }

            return View(materialDTO);
        }

        // GET: Courses/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Courses == null)
        //    {
        //        return NotFound();
        //    }

        //    var course = await _courseService.GetAsync(id);
        //    if (course == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(course);
        //}

        //// POST: Courses/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatorUserName")] CourseDTO course)
        //{
        //    if (id != course.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            await _courseService.UpdateAsync(course);
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CourseExists(course.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(course);
        //}

        // GET: Courses/Delete/5
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

namespace LearnPortalASP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using LearnPortalASP.Data;
    using LearnPortalASP.BLL.DataServices;
    using LearnPortalASP.BLL.DTO;

    public class SkillsController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly SkillService _skillService;

        public SkillsController(ApplicationContext context)
        {
            _context = context;
            _skillService = new SkillService(context);
        }

        // GET: Skills
        public async Task<IActionResult> Index()
        {
            var skills = await _skillService.GetAllAsync();

            return skills != null ?
                View(skills) :
                Problem("Entity set 'ApplicationContext.Courses'  is null.");
        }

        // GET: Skills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Skills/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Id")] SkillDTO skill)
        {
            if (ModelState.IsValid)
            {
                await _skillService.CreateAsync(skill);
                return RedirectToAction(nameof(Index));
            }

            return View(skill);
        }

        // GET: Skills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Id")] SkillDTO skill)
        {
            if (id != skill.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _skillService.UpdateAsync(skill);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SkillExists(skill.Id))
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

            return View(skill);
        }

        // GET: Skills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Skills == null)
            {
                return NotFound();
            }

            var skill = await _skillService.GetAsync(id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Skills == null)
            {
                return Problem("Entity set 'ApplicationContext.Skills'  is null.");
            }

            var skill = await _skillService.GetAsync(id);
            if (skill != null)
            {
                await _skillService.DeleteAsync(id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool SkillExists(int id)
        {
          return _context.Skills.Any(e => e.Id == id);
        }
    }
}

﻿namespace LearnPortalASP.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using LearnPortalASP.BLL.DataServices;
    using LearnPortalASP.BLL.DTO;
    using LearnPortalASP.Data;
    using LearnPortalASP.Models.ViewModels;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class CoursesController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly CourseService _courseService;
        private readonly SkillService _skillService;

        public CoursesController(ApplicationContext context)
        {
            _context = context;
            _courseService = new CourseService(_context);
            _skillService = new SkillService(_context);
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var courses = await _courseService.GetAllAsync();

            return courses != null ?
                        View(courses) :
                        Problem("Entity set 'ApplicationContext.Courses'  is null.");
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public async Task<IActionResult> Create()
        {
            var model = new CourseViewModel();
            model.SkillSelectList = await BindSkillList();

            return View(model);
        }

        public async Task<List<SelectListItem>> BindSkillList()
        {
            var skills = await _context.Skills.ToListAsync();

            List<SelectListItem> skillList = new List<SelectListItem>();

            foreach (var skill in skills)
            {
                skillList.Add(new SelectListItem { Text = skill.Name, Value = skill.Id.ToString() });
            }

            return skillList;
        }

        // [Bind("Id,Name,Description,CreatorUserName,CourseSkills")] CourseDTO course
        // POST: Courses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CourseViewModel courseViewModel)
        {
            if (ModelState.IsValid)
            {
                await _courseService.CreateAsync(courseViewModel);
                return RedirectToAction(nameof(Index));
            }
             
            return View(courseViewModel);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,CreatorUserName")] CourseDTO course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _courseService.UpdateAsync(course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
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

            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Courses == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetAsync(id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Courses == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Courses'  is null.");
            }

            var course = await _courseService.GetAsync(id);
            if (course != null)
            {
                await _courseService.DeleteAsync(course.Id);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_context.Courses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

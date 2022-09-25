using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LearnPortalASP.Data;
using LearnPortalASP.Models.MaterialType;
using LearnPortalASP.BLL.DataServices;
using LearnPortalASP.BLL.DTO;

namespace LearnPortalASP.Controllers
{
    public class VideosController : Controller
    {
        private readonly ApplicationContext _context;
        private readonly VideoService _videoService;
        private readonly MaterialService _materialService;

        public VideosController(ApplicationContext context)
        {
            _context = context;
            _videoService = new VideoService(context);
            _materialService = new MaterialService(context);
        }

        // GET: Videos
        public async Task<IActionResult> Index()
        {
            var books = await _videoService.GetAllAsync();

            return books != null ?
                        View(books) :
                        Problem("Entity set 'ApplicationContext.Courses'  is null.");
        }

        // GET: Videos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _videoService.GetAsync(id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Videos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Videos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Resolution,Duration,Id,Title,CreatorUserName,Discriminator")] VideoDTO video)
        {
            if (ModelState.IsValid)
            {
                await _videoService.CreateAsync(video);
                return RedirectToAction(nameof(Index));
            }

            return View(video);
        }

        // GET: Videos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var book = await _videoService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return View(book);
        }

        // POST: Videos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Resolution,Duration,Id,Title,CreatorUserName,Discriminator")] VideoDTO video)
        {
            if (id != video.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _videoService.UpdateAsync(video);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VideoExists(video.Id))
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
            return View(video);
        }

        // GET: Videos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var book = await _videoService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Videos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Videos == null)
            {
                return Problem("Entity set 'ApplicationContext.Books'  is null.");
            }
            var book = await _videoService.GetAsync(id);
            if (book != null)
            {
                await _materialService.DeleteAsync(id);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
          return _context.Videos.Any(e => e.Id == id);
        }
    }
}

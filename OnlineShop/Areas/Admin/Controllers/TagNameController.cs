using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Data;
using OnlineShop.Models;

namespace OnlineShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class TagNameController : Controller
    {
        private ApplicationDbContext _db;

        public TagNameController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.TagName.ToList());
        }

        // Create Get Action Method

        public ActionResult Create()
        {
            return View();
        }

        // Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(TagName Tag)
        {
            if (ModelState.IsValid)
            {
                _db.TagName.Add(Tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(Tag);
        }

        // Edit Get Action Method

        public ActionResult Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var tag = _db.TagName.Find(id);

            if(tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // Edit Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(TagName Tag)
        {
            if(ModelState.IsValid)
            {
                _db.Update(Tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Tag);
        }

        // Details Get Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _db.TagName.Find(id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // Details Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Details(TagName Tag)
        {
           
                return RedirectToAction(nameof(Index));
            
        }

        // Delete Get Action Method

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = _db.TagName.Find(id);

            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // Delete Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, TagName Tag)
        {
            if(id== null)
            {
                return NotFound();
            }
            if(id !=Tag.Id)
            {
                return NotFound();
            }
            var tag = _db.TagName.Find(id);

            if (tag == null)
            {
                return NotFound();
            }

            if(ModelState.IsValid)
            {
                _db.Remove(tag);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Tag);

        }

    }
}
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

    public class ProductTypesController : Controller
    {
        private ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        // Create Get Action Method
       
        public ActionResult Create()
        {
            return View();
        }

        // Create Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.ProductTypes.Add(productTypes);
                await _db.SaveChangesAsync();

                TempData["save"] = "Product Type Save Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(productTypes);
        }

        // Edit Get Action Method
       
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // Edit Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(ProductTypes productTypes)
        {
            if (ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();

                TempData["update"] = "Update Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(productTypes);
        }

        // Details Get Action Method

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // Details Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Details(ProductTypes productTypes)
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
            var productType = _db.ProductTypes.Find(id);
            if (productType == null)
            {
                return NotFound();
            }
            return View(productType);
        }

        // Delete Post Action Method

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Delete(int? id, ProductTypes productTypes)
        {
            if(id==null)
            {
                return NotFound();
            }
            if(id!=productTypes.Id)
            {
                return NotFound();
            }

            var productType = _db.ProductTypes.Find(id);
            if(productType==null)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _db.Remove(productType);
                await _db.SaveChangesAsync();

                TempData["remove"] = "Delete Successfully";
                return RedirectToAction(nameof(Index));

            }
            return View(productTypes);
        }

    }
}
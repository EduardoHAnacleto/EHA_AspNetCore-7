using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHA_AspNetCore_Angular.Data;
using EHA_AspNetCore_Angular.Models.Products;
using EHA_AspNetCore.Repository;
using EHA_AspNetCore.Services.Interfaces;

namespace EHA_AspNetCore.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoryRepo;
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryRepository context, ICategoryService service)
        {
            _categoryRepo = context;
            _service = service;
        }

        // GET: Categories
        public async Task<IActionResult> Index()
        {
            List<Category> objCategoryList = _categoryRepo.GetAll().ToList();
            return View(objCategoryList);
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _categoryRepo == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _categoryRepo.Get(e => e.Id == id);
            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,DisplayOrder,UrlImage,Id")] Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepo.Add(category);
                _categoryRepo.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id == 0 || _categoryRepo == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _categoryRepo.Get(e => e.Id == id);

            return View(categoryFromDb);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,DisplayOrder,UrlImage,Id")] Category category)
        {
            if (id != category.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _categoryRepo.Update(category);
                    _categoryRepo.Save();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _categoryRepo == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _categoryRepo.Get( e => e.Id == id );

            if (categoryFromDb == null)
            {
                return NotFound();
            }

            return View(categoryFromDb);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_categoryRepo == null)
            {
                return NotFound();
            }

            Category? categoryFromDb = _categoryRepo.Get(e => e.Id == id);

            if (categoryFromDb != null)
            {
                _categoryRepo.Delete(categoryFromDb);
            }

            if (_service.CheckIfForeignKey(id))
            {
                return Conflict();
            }
            else
            {
                _categoryRepo.Save();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            if (_categoryRepo.Get(e => e.Id == id) != null)
            {
                return true;
            }
            else return false;
        }
    }
}

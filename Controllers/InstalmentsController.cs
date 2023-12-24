using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHA_AspNetCore.Controllers
{
    public class InstalmentsController : Controller
    {
        private readonly AppDbContext _context;

        public InstalmentsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: InstalmentsController
        public ActionResult Index()
        {
            return View();
        }

        // GET: InstalmentsController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InstalmentsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InstalmentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection)
        {
            try
            {
                _context.Add(collection);
                await _context.SaveChangesAsync();
                return Ok();
                //return RedirectToAction(nameof(Index));

            }
            catch
            {
                return View();
            }
        }

        // GET: InstalmentsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InstalmentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: InstalmentsController/Delete/5
        public ActionResult Delete(int id)
        {

            return View();
        }

        // POST: InstalmentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                _context.RemoveRange(id);
                await _context.SaveChangesAsync();
                return Ok();
                //return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

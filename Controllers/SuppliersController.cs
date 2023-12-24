using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHA_AspNetCore.Models.People;
using EHA_AspNetCore.Data;
using EHA_AspNetCore.Services.Interfaces;
using EHA_AspNetCore.Services;
using Newtonsoft.Json.Linq;

namespace EHA_AspNetCore.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ISupplierService _supplierService;

        public SuppliersController(AppDbContext context, ISupplierService supplierService)
        {
            _context = context;
            _supplierService = supplierService;
        }

        // GET: Suppliers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Suppliers.Include(s => s.PaymentCondition);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Suppliers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.PaymentCondition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        [HttpGet]
        public async Task<IActionResult> GetGeoLocationApi(string? jsonZip)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonZip);
                string zipCode = jsonObject["zipCode"].ToString();
                string countryName = jsonObject["country"].ToString();
                var result = await _supplierService.ZipCodeAPI(zipCode, countryName);
                return Json(result);
            }
            catch (Exception ex)
            {
                return Json(new { error = ex.Message });
            }
        }

        // GET: Suppliers/Create
        public IActionResult Create()
        {
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name");
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StateInscription,SocialReason,PaymentConditionId,Name,Gender,DateOfBirth,Email,Street,District,BuildingNumber,AddressAddition,ZipCode,City,Country,PhoneNumber,Id")] Supplier supplier)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supplier);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", supplier.PaymentConditionId);
            return View(supplier);
        }

        // GET: Suppliers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier == null)
            {
                return NotFound();
            }
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", supplier.PaymentConditionId);
            return View(supplier);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StateInscription,SocialReason,PaymentConditionId,Name,Gender,DateOfBirth,Email,Street,District,BuildingNumber,AddressAddition,ZipCode,City,Country,PhoneNumber,Id")] Supplier supplier)
        {
            if (id != supplier.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supplier);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupplierExists(supplier.Id))
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
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", supplier.PaymentConditionId);
            return View(supplier);
        }

        // GET: Suppliers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supplier = await _context.Suppliers
                .Include(s => s.PaymentCondition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (supplier == null)
            {
                return NotFound();
            }

            return View(supplier);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supplier = await _context.Suppliers.FindAsync(id);
            if (supplier != null)
            {
                _context.Suppliers.Remove(supplier);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupplierExists(int id)
        {
            return _context.Suppliers.Any(e => e.Id == id);
        }
    }
}

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
using Newtonsoft.Json.Linq;
using System.Text.Json.Serialization;
using System.Text.Json.Nodes;

namespace EHA_AspNetCore.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly ICustomerService _customerService;

        public CustomersController(AppDbContext context, ICustomerService customerService)
        {
            _context = context;
            _customerService = customerService;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Customers.Include(c => c.PaymentCondition);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.PaymentCondition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        [HttpGet]
        public async Task<IActionResult> GetGeoLocationApi(string? jsonZip)
        {
            try
            {
                JObject jsonObject = JObject.Parse(jsonZip);
                string zipCode = jsonObject["zipCode"].ToString();
                string countryName = jsonObject["country"].ToString();
                var result = await _customerService.ZipCodeAPI(zipCode, countryName);
                return Json(result);
            }
            catch(Exception ex)
            {
                return Json(new { error = ex.Message }); 
            }
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name");
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CustomerType,PaymentConditionId,Name,Gender,DateOfBirth,Email,Street,District,BuildingNumber,AddressAddition,ZipCode,City,Country,PhoneNumber,Id")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", customer.PaymentConditionId);
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", customer.PaymentConditionId);
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerType,PaymentConditionId,Name,Gender,DateOfBirth,Email,Street,District,BuildingNumber,AddressAddition,ZipCode,City,Country,PhoneNumber,Id")] Customer customer)
        {
            if (id != customer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Id))
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
            ViewData["PaymentConditionId"] = new SelectList(_context.PaymentConditions, "Id", "Name", customer.PaymentConditionId);
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers
                .Include(c => c.PaymentCondition)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.Id == id);
        }
    }
}

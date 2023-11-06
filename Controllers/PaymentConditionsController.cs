using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore_Angular.Data;

namespace EHA_AspNetCore.Controllers
{
    public class PaymentConditionsController : Controller
    {
        private readonly AppDbContext _context;

        public PaymentConditionsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: PaymentConditions
        public async Task<IActionResult> Index()
        {
              return View(await _context.PaymentConditions.ToListAsync());
        }

        // GET: PaymentConditions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PaymentConditions == null)
            {
                return NotFound();
            }

            var paymentCondition = await _context.PaymentConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentCondition == null)
            {
                return NotFound();
            }

            return View(paymentCondition);
        }

        // GET: PaymentConditions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PaymentConditions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Fee,Discount,Fine,Id")] PaymentCondition paymentCondition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentCondition);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentCondition);
        }

        // GET: PaymentConditions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PaymentConditions == null)
            {
                return NotFound();
            }

            var paymentCondition = await _context.PaymentConditions.FindAsync(id);
            if (paymentCondition == null)
            {
                return NotFound();
            }
            return View(paymentCondition);
        }

        // POST: PaymentConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Fee,Discount,Fine,Id")] PaymentCondition paymentCondition)
        {
            if (id != paymentCondition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentCondition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentConditionExists(paymentCondition.Id))
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
            return View(paymentCondition);
        }

        // GET: PaymentConditions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PaymentConditions == null)
            {
                return NotFound();
            }

            var paymentCondition = await _context.PaymentConditions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (paymentCondition == null)
            {
                return NotFound();
            }

            return View(paymentCondition);
        }

        // POST: PaymentConditions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PaymentConditions == null)
            {
                return Problem("Entity set 'AppDbContext.PaymentConditions'  is null.");
            }
            var paymentCondition = await _context.PaymentConditions.FindAsync(id);
            if (paymentCondition != null)
            {
                _context.PaymentConditions.Remove(paymentCondition);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentConditionExists(int id)
        {
          return _context.PaymentConditions.Any(e => e.Id == id);
        }
    }
}

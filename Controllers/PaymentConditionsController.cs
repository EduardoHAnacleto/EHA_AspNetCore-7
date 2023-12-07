using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EHA_AspNetCore.Models.Payments;
using EHA_AspNetCore_Angular.Data;
using Newtonsoft.Json;
using System.Text.Json.Serialization;
using Azure;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Http.HttpResults;
using EHA_AspNetCore.DTOs;
using Microsoft.AspNetCore.Components;
using System.IdentityModel.Tokens.Jwt;
using EHA_AspNetCore.Services;
using EHA_AspNetCore.Services.Interfaces;
using NuGet.Packaging;

namespace EHA_AspNetCore.Controllers
{
    public class PaymentConditionsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IInstalmentService _instalmentService;
        private readonly IPaymentConditionService _paymentConditionService;

        public PaymentConditionsController(AppDbContext context, IInstalmentService instalmentService, IPaymentConditionService paymentConditionService)
        {
            _context = context;
            _instalmentService = instalmentService;
            _paymentConditionService = paymentConditionService;
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
            else
            {
                paymentCondition = _paymentConditionService.PopulateFullObject(paymentCondition);
            }

            return View(paymentCondition);
        }

        // GET: PaymentConditions/Create
        public IActionResult Create()
        {
            ViewData["PaymentMethods"] = new SelectList(_context.PaymentMethods, "Id", "Name");
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
                //await _instalmentController.Create(GetInstalments());
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentCondition);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateWithInstalment([Bind("Name,Fee,Discount,Fine,Id")] PaymentCondition paymentCondition)
        {
            var jsonInstalmentList = Request.Form["instalmentList"];
            var instalmentDtoList = JsonConvert.DeserializeObject<List<InstalmentDTO>>(jsonInstalmentList);

            if (ModelState.IsValid && instalmentDtoList != null)
            {
                _context.Add(paymentCondition);
                await _context.SaveChangesAsync();

                var instalmentList = _instalmentService.MapDtoToClass(instalmentDtoList);
                instalmentList = _instalmentService.SetId(paymentCondition.Id, instalmentList);
                instalmentList = _instalmentService.SetPaymentMethod(instalmentList);

                _context.Instalments.AddRange(instalmentList);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(nameof(Index));
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
            else
            {
                paymentCondition = _paymentConditionService.PopulateFullObject(paymentCondition);
            }
            ViewData["PaymentMethods"] = new SelectList(_context.PaymentMethods, "Id", "Name");
            return View(paymentCondition);
        }

        // POST: PaymentConditions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to. EditWithInstalment
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditWithInstalment(int id, [Bind("Name,Fee,Discount,Fine,Id")] PaymentCondition paymentCondition)
        {
            if (id != paymentCondition.Id)
            {
                return NotFound();
            }

            var jsonInstalmentList = Request.Form["instalmentList"];
            var instalmentDtoList = JsonConvert.DeserializeObject<List<InstalmentDTO>>(jsonInstalmentList);

            if (ModelState.IsValid && instalmentDtoList != null)
            {
                try
                {

                    _context.Update(paymentCondition);
                    var instalmentList = _instalmentService.MapDtoToClass(instalmentDtoList);
                    instalmentList = _instalmentService.SetId(paymentCondition.Id, instalmentList);
                    instalmentList = _instalmentService.SetPaymentMethod(instalmentList);
                    var listToRemove = _instalmentService.RemoveExistingInstalments(paymentCondition.Id);
                    _context.Instalments.RemoveRange(listToRemove);
                    _context.Instalments.AddRange(instalmentList);

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
            return RedirectToAction(nameof(Index));
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
            else
            {
                paymentCondition = _paymentConditionService.PopulateFullObject(paymentCondition);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RelevantPizza.Data;
using RelevantPizza.Models;

namespace RelevantPizza.Controllers
{
    public class OrderItemDetailsController : Controller
    {
        private readonly PizzaContext _context;

        public OrderItemDetailsController(PizzaContext context)
        {
            _context = context;
        }

        // GET: OrderItemDetails
        public async Task<IActionResult> Index()
        {
            return View(await _context.OrderItemDetails.ToListAsync());
        }

        // GET: OrderItemDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemDetail = await _context.OrderItemDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderItemDetail == null)
            {
                return NotFound();
            }

            return View(orderItemDetail);
        }

        // GET: OrderItemDetails/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: OrderItemDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Type")] OrderItemDetail orderItemDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderItemDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(orderItemDetail);
        }

        // GET: OrderItemDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemDetail = await _context.OrderItemDetails.FindAsync(id);
            if (orderItemDetail == null)
            {
                return NotFound();
            }
            return View(orderItemDetail);
        }

        // POST: OrderItemDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Type")] OrderItemDetail orderItemDetail)
        {
            if (id != orderItemDetail.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderItemDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderItemDetailExists(orderItemDetail.ID))
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
            return View(orderItemDetail);
        }

        // GET: OrderItemDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderItemDetail = await _context.OrderItemDetails
                .FirstOrDefaultAsync(m => m.ID == id);
            if (orderItemDetail == null)
            {
                return NotFound();
            }

            return View(orderItemDetail);
        }

        // POST: OrderItemDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderItemDetail = await _context.OrderItemDetails.FindAsync(id);
            _context.OrderItemDetails.Remove(orderItemDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderItemDetailExists(int id)
        {
            return _context.OrderItemDetails.Any(e => e.ID == id);
        }
    }
}

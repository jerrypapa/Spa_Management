using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;

namespace Spa_Management.Controllers
{
    public class CurrenciesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurrenciesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Currencies
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbCurrencies.ToListAsync());
        }

        // GET: Currencies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurrencies = await _context.TbCurrencies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbCurrencies == null)
            {
                return NotFound();
            }

            return View(tbCurrencies);
        }

        // GET: Currencies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Currencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,currency")] tbCurrencies tbCurrencies)
        {
            tbCurrencies Curr = await _context.TbCurrencies.SingleOrDefaultAsync(m => m.currency == tbCurrencies.currency);


            if (ModelState.IsValid)
            {
                if(Curr != null)
                {
                    ModelState.AddModelError(string.Empty, "This currency already exists");
                    return View(tbCurrencies);
                }
                else
                {
                    _context.Add(tbCurrencies);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }              
            }
            return View(tbCurrencies);
        }

        // GET: Currencies/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurrencies = await _context.TbCurrencies.SingleOrDefaultAsync(m => m.Id == id);
            if (tbCurrencies == null)
            {
                return NotFound();
            }
            return View(tbCurrencies);
        }

        // POST: Currencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,currency")] tbCurrencies tbCurrencies)
        {
            if (id != tbCurrencies.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCurrencies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbCurrenciesExists(tbCurrencies.Id))
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
            return View(tbCurrencies);
        }

        // GET: Currencies/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCurrencies = await _context.TbCurrencies
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbCurrencies == null)
            {
                return NotFound();
            }

            return View(tbCurrencies);
        }

        // POST: Currencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbCurrencies = await _context.TbCurrencies.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbCurrencies.Remove(tbCurrencies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbCurrenciesExists(int id)
        {
            return _context.TbCurrencies.Any(e => e.Id == id);
        }
    }
}

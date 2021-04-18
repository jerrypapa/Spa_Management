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
    public class PostalCodesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PostalCodesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PostalCodes
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbPostalCodes.ToListAsync());
        }

        // GET: PostalCodes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPostalCodes = await _context.tbPostalCodes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbPostalCodes == null)
            {
                return NotFound();
            }

            return View(tbPostalCodes);
        }

        // GET: PostalCodes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PostalCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Status,RegionName")] tbPostalCodes tbPostalCodes)
        {
            if (ModelState.IsValid)
            {
                tbPostalCodes.Id = Guid.NewGuid();
                _context.Add(tbPostalCodes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbPostalCodes);
        }

        // GET: PostalCodes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPostalCodes = await _context.tbPostalCodes.SingleOrDefaultAsync(m => m.Id == id);
            if (tbPostalCodes == null)
            {
                return NotFound();
            }
            return View(tbPostalCodes);
        }

        // POST: PostalCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Status,RegionName")] tbPostalCodes tbPostalCodes)
        {
            if (id != tbPostalCodes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbPostalCodes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbPostalCodesExists(tbPostalCodes.Id))
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
            return View(tbPostalCodes);
        }

        // GET: PostalCodes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbPostalCodes = await _context.tbPostalCodes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbPostalCodes == null)
            {
                return NotFound();
            }

            return View(tbPostalCodes);
        }

        // POST: PostalCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbPostalCodes = await _context.tbPostalCodes.SingleOrDefaultAsync(m => m.Id == id);
            _context.tbPostalCodes.Remove(tbPostalCodes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbPostalCodesExists(Guid id)
        {
            return _context.tbPostalCodes.Any(e => e.Id == id);
        }
    }
}

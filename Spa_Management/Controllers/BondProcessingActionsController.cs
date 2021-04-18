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
    public class BondProcessingActionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BondProcessingActionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BondProcessingActions
        public async Task<IActionResult> Index()
        {
            return View(await _context.BondProcessingActions.ToListAsync());
        }

        // GET: BondProcessingActions/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBondProcessingActions = await _context.BondProcessingActions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbBondProcessingActions == null)
            {
                return NotFound();
            }

            return View(tbBondProcessingActions);
        }

        // GET: BondProcessingActions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BondProcessingActions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Code,Description,Status")] tbBondProcessingActions tbBondProcessingActions)
        {
            if (ModelState.IsValid)
            {
                tbBondProcessingActions.Id = Guid.NewGuid();
                _context.Add(tbBondProcessingActions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbBondProcessingActions);
        }

        // GET: BondProcessingActions/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBondProcessingActions = await _context.BondProcessingActions.SingleOrDefaultAsync(m => m.Id == id);
            if (tbBondProcessingActions == null)
            {
                return NotFound();
            }
            return View(tbBondProcessingActions);
        }

        // POST: BondProcessingActions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Code,Description,Status")] tbBondProcessingActions tbBondProcessingActions)
        {
            if (id != tbBondProcessingActions.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBondProcessingActions);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBondProcessingActionsExists(tbBondProcessingActions.Id))
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
            return View(tbBondProcessingActions);
        }

        // GET: BondProcessingActions/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBondProcessingActions = await _context.BondProcessingActions
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbBondProcessingActions == null)
            {
                return NotFound();
            }

            return View(tbBondProcessingActions);
        }

        // POST: BondProcessingActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbBondProcessingActions = await _context.BondProcessingActions.SingleOrDefaultAsync(m => m.Id == id);
            _context.BondProcessingActions.Remove(tbBondProcessingActions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbBondProcessingActionsExists(Guid id)
        {
            return _context.BondProcessingActions.Any(e => e.Id == id);
        }
    }
}

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
    public class DesignationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DesignationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Designations
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbDesignations.ToListAsync());
        }

        // GET: Designations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDesignations = await _context.TbDesignations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbDesignations == null)
            {
                return NotFound();
            }

            return View(tbDesignations);
        }

        // GET: Designations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Designations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,designation")] tbDesignations tbDesignations)
        {
            tbDesignations existingDesignations = await _context.TbDesignations.SingleOrDefaultAsync(
                  m => m.designation == tbDesignations.designation);

            if (ModelState.IsValid)
            {
                if (existingDesignations != null)
                {
                    ModelState.AddModelError(string.Empty, "This designation already exists.");
                    return View(tbDesignations);
                }
                else
                {
                    _context.Add(tbDesignations);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
              
            }
            return View(tbDesignations);
        }

        // GET: Designations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDesignations = await _context.TbDesignations.SingleOrDefaultAsync(m => m.Id == id);
            if (tbDesignations == null)
            {
                return NotFound();
            }
            return View(tbDesignations);
        }

        // POST: Designations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,designation")] tbDesignations tbDesignations)
        {
            if (id != tbDesignations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDesignations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbDesignationsExists(tbDesignations.Id))
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
            return View(tbDesignations);
        }

        // GET: Designations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDesignations = await _context.TbDesignations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbDesignations == null)
            {
                return NotFound();
            }

            return View(tbDesignations);
        }

        // POST: Designations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDesignations = await _context.TbDesignations.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbDesignations.Remove(tbDesignations);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbDesignationsExists(int id)
        {
            return _context.TbDesignations.Any(e => e.Id == id);
        }
    }
}

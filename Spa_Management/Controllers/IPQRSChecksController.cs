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
    public class IPQRSChecksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IPQRSChecksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IPQRSChecks
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.TbIPQRSChecks.Include(t => t.tbIndivuduals);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: IPQRSChecks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIPQRSChecks = await _context.TbIPQRSChecks
                .Include(t => t.tbIndivuduals)
                .SingleOrDefaultAsync(m => m.ipqrsGuid == id);
            if (tbIPQRSChecks == null)
            {
                return NotFound();
            }

            return View(tbIPQRSChecks);
        }

        // GET: IPQRSChecks/Create
        public IActionResult Create()
        {
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName");
            return View();
        }

        // POST: IPQRSChecks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ipqrsGuid,indGuid,inComeDetails,score,status,date")] tbIPQRSChecks tbIPQRSChecks)
        {
            if (ModelState.IsValid)
            {
                tbIPQRSChecks.ipqrsGuid = Guid.NewGuid();
                _context.Add(tbIPQRSChecks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbIPQRSChecks.indGuid);
            return View(tbIPQRSChecks);
        }

        // GET: IPQRSChecks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIPQRSChecks = await _context.TbIPQRSChecks.SingleOrDefaultAsync(m => m.ipqrsGuid == id);
            if (tbIPQRSChecks == null)
            {
                return NotFound();
            }
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbIPQRSChecks.indGuid);
            return View(tbIPQRSChecks);
        }

        // POST: IPQRSChecks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("ipqrsGuid,indGuid,inComeDetails,score,status,date")] tbIPQRSChecks tbIPQRSChecks)
        {
            if (id != tbIPQRSChecks.ipqrsGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbIPQRSChecks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbIPQRSChecksExists(tbIPQRSChecks.ipqrsGuid))
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
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbIPQRSChecks.indGuid);
            return View(tbIPQRSChecks);
        }

        // GET: IPQRSChecks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIPQRSChecks = await _context.TbIPQRSChecks
                .Include(t => t.tbIndivuduals)
                .SingleOrDefaultAsync(m => m.ipqrsGuid == id);
            if (tbIPQRSChecks == null)
            {
                return NotFound();
            }

            return View(tbIPQRSChecks);
        }

        // POST: IPQRSChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbIPQRSChecks = await _context.TbIPQRSChecks.SingleOrDefaultAsync(m => m.ipqrsGuid == id);
            _context.TbIPQRSChecks.Remove(tbIPQRSChecks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbIPQRSChecksExists(Guid id)
        {
            return _context.TbIPQRSChecks.Any(e => e.ipqrsGuid == id);
        }
    }
}

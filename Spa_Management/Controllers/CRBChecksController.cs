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
    public class CRBChecksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CRBChecksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CRBChecks
        public async Task<IActionResult> Index()

        {
            var ApplicationDbContext = _context.TbCRBChecks;//.Include(t => t.tbIndivuduals);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: CRBChecks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCRBChecks = await _context.TbCRBChecks
               // .Include(t => t.tbIndivuduals)
                .SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbCRBChecks == null)
            {
                return NotFound();
            }

            return View(tbCRBChecks);
        }

        // GET: CRBChecks/Create
        public IActionResult Create()
        {
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName");
            return View();
        }

        // POST: CRBChecks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CRBGuid,indGuid,inComeDetails,score,details,status,date")] tbCRBChecks tbCRBChecks)
        {
            if (ModelState.IsValid)
            {
                tbCRBChecks.CRBGuid = Guid.NewGuid();
                _context.Add(tbCRBChecks);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbCRBChecks.indGuid);
            return View(tbCRBChecks);
        }

        // GET: CRBChecks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCRBChecks = await _context.TbCRBChecks.SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbCRBChecks == null)
            {
                return NotFound();
            }
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbCRBChecks.indGuid);
            return View(tbCRBChecks);
        }

        // POST: CRBChecks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CRBGuid,indGuid,inComeDetails,score,details,status,date")] tbCRBChecks tbCRBChecks)
        {
            if (id != tbCRBChecks.CRBGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCRBChecks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbCRBChecksExists(tbCRBChecks.CRBGuid))
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
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbCRBChecks.indGuid);
            return View(tbCRBChecks);
        }

        // GET: CRBChecks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCRBChecks = await _context.TbCRBChecks
               // .Include(t => t.tbIndivuduals)
                .SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbCRBChecks == null)
            {
                return NotFound();
            }

            return View(tbCRBChecks);
        }

        // POST: CRBChecks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbCRBChecks = await _context.TbCRBChecks.SingleOrDefaultAsync(m => m.CRBGuid == id);
            _context.TbCRBChecks.Remove(tbCRBChecks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbCRBChecksExists(Guid id)
        {
            return _context.TbCRBChecks.Any(e => e.CRBGuid == id);
        }
    }
}

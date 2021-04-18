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
    public class ErrorLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ErrorLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ErrorLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbErrorLogs.ToListAsync());
        }

        // GET: ErrorLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbErrorLogs = await _context.TbErrorLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbErrorLogs == null)
            {
                return NotFound();
            }

            return View(tbErrorLogs);
        }

        // GET: ErrorLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ErrorLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,sessionId,action,Description,json,OpDate,errorMessage,innerExemption,modelValidation,attStatus")] tbErrorLogs tbErrorLogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbErrorLogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbErrorLogs);
        }

        // GET: ErrorLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbErrorLogs = await _context.TbErrorLogs.SingleOrDefaultAsync(m => m.Id == id);
            if (tbErrorLogs == null)
            {
                return NotFound();
            }
            return View(tbErrorLogs);
        }

        // POST: ErrorLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,sessionId,action,Description,json,OpDate,errorMessage,innerExemption,modelValidation,attStatus")] tbErrorLogs tbErrorLogs)
        {
            if (id != tbErrorLogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbErrorLogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbErrorLogsExists(tbErrorLogs.Id))
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
            return View(tbErrorLogs);
        }

        // GET: ErrorLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbErrorLogs = await _context.TbErrorLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbErrorLogs == null)
            {
                return NotFound();
            }

            return View(tbErrorLogs);
        }

        // POST: ErrorLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbErrorLogs = await _context.TbErrorLogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbErrorLogs.Remove(tbErrorLogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbErrorLogsExists(int id)
        {
            return _context.TbErrorLogs.Any(e => e.Id == id);
        }
    }
}

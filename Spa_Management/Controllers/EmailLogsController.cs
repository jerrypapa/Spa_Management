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
    public class EmailLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmailLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmailLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbEmailLogs.ToListAsync());
        }

        // GET: EmailLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmailLogs = await _context.TbEmailLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbEmailLogs == null)
            {
                return NotFound();
            }

            return View(tbEmailLogs);
        }

        // GET: EmailLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmailLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,to,from,subject,cc,bcc,message,date,status")] tbEmailLogs tbEmailLogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbEmailLogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbEmailLogs);
        }

        // GET: EmailLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmailLogs = await _context.TbEmailLogs.SingleOrDefaultAsync(m => m.Id == id);
            if (tbEmailLogs == null)
            {
                return NotFound();
            }
            return View(tbEmailLogs);
        }

        // POST: EmailLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,to,from,subject,cc,bcc,message,date,status")] tbEmailLogs tbEmailLogs)
        {
            if (id != tbEmailLogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbEmailLogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbEmailLogsExists(tbEmailLogs.Id))
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
            return View(tbEmailLogs);
        }

        // GET: EmailLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbEmailLogs = await _context.TbEmailLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbEmailLogs == null)
            {
                return NotFound();
            }

            return View(tbEmailLogs);
        }

        // POST: EmailLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbEmailLogs = await _context.TbEmailLogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbEmailLogs.Remove(tbEmailLogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbEmailLogsExists(int id)
        {
            return _context.TbEmailLogs.Any(e => e.Id == id);
        }
    }
}

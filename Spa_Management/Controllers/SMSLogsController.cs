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
    public class SMSLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SMSLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SMSLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSMSLogs.ToListAsync());
        }

        // GET: SMSLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSMSLogs = await _context.TbSMSLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbSMSLogs == null)
            {
                return NotFound();
            }

            return View(tbSMSLogs);
        }

        // GET: SMSLogs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SMSLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,toPhone,message,sentDate,status")] tbSMSLogs tbSMSLogs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSMSLogs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbSMSLogs);
        }

        // GET: SMSLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSMSLogs = await _context.TbSMSLogs.SingleOrDefaultAsync(m => m.Id == id);
            if (tbSMSLogs == null)
            {
                return NotFound();
            }
            return View(tbSMSLogs);
        }

        // POST: SMSLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,toPhone,message,sentDate,status")] tbSMSLogs tbSMSLogs)
        {
            if (id != tbSMSLogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSMSLogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbSMSLogsExists(tbSMSLogs.Id))
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
            return View(tbSMSLogs);
        }

        // GET: SMSLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSMSLogs = await _context.TbSMSLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbSMSLogs == null)
            {
                return NotFound();
            }

            return View(tbSMSLogs);
        }

        // POST: SMSLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSMSLogs = await _context.TbSMSLogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbSMSLogs.Remove(tbSMSLogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbSMSLogsExists(int id)
        {
            return _context.TbSMSLogs.Any(e => e.Id == id);
        }
    }
}

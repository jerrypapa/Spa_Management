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
    public class SysConfigsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SysConfigsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SysConfigs
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSysConfigs.ToListAsync());
        }

        // GET: SysConfigs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSysConfigs = await _context.TbSysConfigs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbSysConfigs == null)
            {
                return NotFound();
            }

            return View(tbSysConfigs);
        }

        // GET: SysConfigs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SysConfigs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,code,Value,status")] tbSysConfigs tbSysConfigs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbSysConfigs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbSysConfigs);
        }

        // GET: SysConfigs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSysConfigs = await _context.TbSysConfigs.SingleOrDefaultAsync(m => m.Id == id);
            if (tbSysConfigs == null)
            {
                return NotFound();
            }
            return View(tbSysConfigs);
        }

        // POST: SysConfigs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,code,Value,status")] tbSysConfigs tbSysConfigs)
        {
            if (id != tbSysConfigs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSysConfigs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbSysConfigsExists(tbSysConfigs.Id))
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
            return View(tbSysConfigs);
        }

        // GET: SysConfigs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSysConfigs = await _context.TbSysConfigs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbSysConfigs == null)
            {
                return NotFound();
            }

            return View(tbSysConfigs);
        }

        // POST: SysConfigs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSysConfigs = await _context.TbSysConfigs.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbSysConfigs.Remove(tbSysConfigs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbSysConfigsExists(int id)
        {
            return _context.TbSysConfigs.Any(e => e.Id == id);
        }
    }
}

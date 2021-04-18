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
    public class SuffixesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SuffixesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Suffixes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbSuffixes.ToListAsync());
        }

        // GET: Suffixes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSuffixes = await _context.TbSuffixes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbSuffixes == null)
            {
                return NotFound();
            }

            return View(tbSuffixes);
        }

        // GET: Suffixes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Suffixes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,suffix")] tbSuffixes tbSuffixes)
        {

            tbSuffixes suffix = await _context.TbSuffixes.SingleOrDefaultAsync(m => m.suffix == tbSuffixes.suffix);

            if (ModelState.IsValid)
            {
                if (suffix != null)
                {
                    ModelState.AddModelError(string.Empty, "This Suffix already exists");
                    return View(tbSuffixes);
                }
                else
                {
                    _context.Add(tbSuffixes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }

            }
            return View(tbSuffixes);
        }

        // GET: Suffixes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSuffixes = await _context.TbSuffixes.SingleOrDefaultAsync(m => m.Id == id);
            if (tbSuffixes == null)
            {
                return NotFound();
            }
            return View(tbSuffixes);
        }

        // POST: Suffixes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,suffix")] tbSuffixes tbSuffixes)
        {
            if (id != tbSuffixes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbSuffixes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbSuffixesExists(tbSuffixes.Id))
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
            return View(tbSuffixes);
        }

        // GET: Suffixes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSuffixes = await _context.TbSuffixes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbSuffixes == null)
            {
                return NotFound();
            }

            return View(tbSuffixes);
        }

        // POST: Suffixes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbSuffixes = await _context.TbSuffixes.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbSuffixes.Remove(tbSuffixes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbSuffixesExists(int id)
        {
            return _context.TbSuffixes.Any(e => e.Id == id);
        }
    }
}

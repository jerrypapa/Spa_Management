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
    public class IdTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IdTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: IdTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbIdTypes.ToListAsync());
        }

        // GET: IdTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIdTypes = await _context.TbIdTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbIdTypes == null)
            {
                return NotFound();
            }

            return View(tbIdTypes);
        }

        // GET: IdTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: IdTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,idType")] tbIdTypes tbIdTypes)
        {
            if (ModelState.IsValid)
            {
                tbIdTypes existing = await _context.TbIdTypes.SingleOrDefaultAsync(m => m.idType == tbIdTypes.idType);
                if(existing != null)
                {
                    ModelState.AddModelError(string.Empty, "This ID Type already exists");
                    return View(tbIdTypes);
                }
                else
                {
                    _context.Add(tbIdTypes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(tbIdTypes);
        }

        // GET: IdTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIdTypes = await _context.TbIdTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (tbIdTypes == null)
            {
                return NotFound();
            }
            return View(tbIdTypes);
        }

        // POST: IdTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,idType")] tbIdTypes tbIdTypes)
        {
            if (id != tbIdTypes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbIdTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbIdTypesExists(tbIdTypes.Id))
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
            return View(tbIdTypes);
        }

        // GET: IdTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbIdTypes = await _context.TbIdTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbIdTypes == null)
            {
                return NotFound();
            }

            return View(tbIdTypes);
        }

        // POST: IdTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbIdTypes = await _context.TbIdTypes.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbIdTypes.Remove(tbIdTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbIdTypesExists(int id)
        {
            return _context.TbIdTypes.Any(e => e.Id == id);
        }
    }
}

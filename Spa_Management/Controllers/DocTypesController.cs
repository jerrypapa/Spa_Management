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
    public class DocTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DocTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbDocTypes.ToListAsync());
        }

        // GET: DocTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDocTypes = await _context.TbDocTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbDocTypes == null)
            {
                return NotFound();
            }

            return View(tbDocTypes);
        }

        // GET: DocTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DocTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Type,Extensions,status")] tbDocTypes tbDocTypes)
        {
            tbDocTypes existingDoctype = await _context.TbDocTypes.SingleOrDefaultAsync(
                    m => m.Type == tbDocTypes.Type && m.Extensions == tbDocTypes.Extensions);
            tbDocTypes.status = 0;
            if (ModelState.IsValid)
            {
                if(existingDoctype != null)
                {
                    ModelState.AddModelError(string.Empty, "This Doc Type already exists.");
                    return View(tbDocTypes);
                }
                else
                {
                    _context.Add(tbDocTypes);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
            }
            return View(tbDocTypes);
        }

        // GET: DocTypes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDocTypes = await _context.TbDocTypes.SingleOrDefaultAsync(m => m.Id == id);
            if (tbDocTypes == null)
            {
                return NotFound();
            }
            return View(tbDocTypes);
        }

        // POST: DocTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Type,Extensions,status")] tbDocTypes tbDocTypes)
        {
            if (id != tbDocTypes.Id)
            {
                return NotFound();
            }
            tbDocTypes.status = 0;
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbDocTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbDocTypesExists(tbDocTypes.Id))
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
            return View(tbDocTypes);
        }

        // GET: DocTypes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbDocTypes = await _context.TbDocTypes
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbDocTypes == null)
            {
                return NotFound();
            }

            return View(tbDocTypes);
        }

        // POST: DocTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbDocTypes = await _context.TbDocTypes.SingleOrDefaultAsync(m => m.Id == id);
            //_context.TbDocTypes.Remove(tbDocTypes);
            tbDocTypes.status = 1;
            _context.Update(tbDocTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbDocTypesExists(int id)
        {
            return _context.TbDocTypes.Any(e => e.Id == id);
        }
    }
}

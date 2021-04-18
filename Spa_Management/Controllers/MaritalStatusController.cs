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
    public class MaritalStatusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MaritalStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MaritalStatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbMaritalStatuses.ToListAsync());
        }

        // GET: MaritalStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMaritalStatus = await _context.TbMaritalStatuses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbMaritalStatus == null)
            {
                return NotFound();
            }

            return View(tbMaritalStatus);
        }

        // GET: MaritalStatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaritalStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,maritalStatus")] tbMaritalStatus tbMaritalStatus)
        {
            tbMaritalStatus marital = await _context.TbMaritalStatuses.SingleOrDefaultAsync(m => m.maritalStatus == tbMaritalStatus.maritalStatus);

            if (ModelState.IsValid)
            {
                if (marital != null)
                {
                    ModelState.AddModelError(string.Empty, "This Status already exists");
                    return View(tbMaritalStatus);
                }
                else
                {
                    _context.Add(tbMaritalStatus);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            
            }
            return View(tbMaritalStatus);
        }

        // GET: MaritalStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMaritalStatus = await _context.TbMaritalStatuses.SingleOrDefaultAsync(m => m.Id == id);
            if (tbMaritalStatus == null)
            {
                return NotFound();
            }
            return View(tbMaritalStatus);
        }

        // POST: MaritalStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,maritalStatus")] tbMaritalStatus tbMaritalStatus)
        {
            if (id != tbMaritalStatus.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMaritalStatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbMaritalStatusExists(tbMaritalStatus.Id))
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
            return View(tbMaritalStatus);
        }

        // GET: MaritalStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbMaritalStatus = await _context.TbMaritalStatuses
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbMaritalStatus == null)
            {
                return NotFound();
            }

            return View(tbMaritalStatus);
        }

        // POST: MaritalStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbMaritalStatus = await _context.TbMaritalStatuses.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbMaritalStatuses.Remove(tbMaritalStatus);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbMaritalStatusExists(int id)
        {
            return _context.TbMaritalStatuses.Any(e => e.Id == id);
        }
    }
}

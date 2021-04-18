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
    public class NationalitiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NationalitiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Nationalities
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbNationalities.ToListAsync());
        }

        // GET: Nationalities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNationalities = await _context.TbNationalities
                .SingleOrDefaultAsync(m => m.id == id);
            if (tbNationalities == null)
            {
                return NotFound();
            }

            return View(tbNationalities);
        }

        // GET: Nationalities/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Nationalities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NationCode,Nationality")] tbNationalities tbNationalities)
        {
            tbNationalities nation = await _context.TbNationalities.SingleOrDefaultAsync(m => m.NationCode == tbNationalities.NationCode);

            if (ModelState.IsValid)
            {
                if(nation != null)
                {
                    ModelState.AddModelError(string.Empty, "This nationality already exists");
                    return View(tbNationalities);
                }
                else
                {
                    _context.Add(tbNationalities);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
              
            }
            return View(tbNationalities);
        }

        // GET: Nationalities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNationalities = await _context.TbNationalities.SingleOrDefaultAsync(m => m.id == id);
            if (tbNationalities == null)
            {
                return NotFound();
            }
            return View(tbNationalities);
        }

        // POST: Nationalities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NationCode,Nationality")] tbNationalities tbNationalities)
        {
            if (id != tbNationalities.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbNationalities);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbNationalitiesExists(tbNationalities.id))
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
            return View(tbNationalities);
        }

        // GET: Nationalities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNationalities = await _context.TbNationalities
                .SingleOrDefaultAsync(m => m.id == id);
            if (tbNationalities == null)
            {
                return NotFound();
            }

            return View(tbNationalities);
        }

        // POST: Nationalities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbNationalities = await _context.TbNationalities.SingleOrDefaultAsync(m => m.id == id);
            _context.TbNationalities.Remove(tbNationalities);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbNationalitiesExists(int id)
        {
            return _context.TbNationalities.Any(e => e.id == id);
        }
    }
}

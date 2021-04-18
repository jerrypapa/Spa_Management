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
    public class GendersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GendersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Genders
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbGenders.ToListAsync());
        }

        // GET: Genders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGender = await _context.TbGenders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbGender == null)
            {
                return NotFound();
            }

            return View(tbGender);
        }

        // GET: Genders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Genders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,gender")] tbGender tbGender)
        {
            tbGender existingGenders = await _context.TbGenders.SingleOrDefaultAsync(m => m.gender == tbGender.gender);
            if (ModelState.IsValid)
            {
                if(existingGenders != null)
                {
                    ModelState.AddModelError(string.Empty, "This gender already exists.");
                    return View(tbGender);
                }
                else
                {
                    _context.Add(tbGender);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
             
            }
            return View(tbGender);
        }

        // GET: Genders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGender = await _context.TbGenders.SingleOrDefaultAsync(m => m.Id == id);
            if (tbGender == null)
            {
                return NotFound();
            }
            return View(tbGender);
        }

        // POST: Genders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,gender")] tbGender tbGender)
        {
            //if (id != tbGender.gender)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbGender);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbGenderExists(tbGender.Id))
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
            return View(tbGender);
        }

        // GET: Genders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbGender = await _context.TbGenders
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbGender == null)
            {
                return NotFound();
            }

            return View(tbGender);
        }

        // POST: Genders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbGender = await _context.TbGenders.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbGenders.Remove(tbGender);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbGenderExists(int id)
        {
            return _context.TbGenders.Any(e => e.Id == id);
        }
    }
}

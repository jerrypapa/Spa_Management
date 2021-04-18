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
    public class EmployeePaysController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeePaysController(ApplicationDbContext context)
        {
            _context = context;
        }


        // GET: EmployeePays
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.EmployeePays_.Include(e => e.SpaUsers);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: EmployeePays/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePay = await _context.EmployeePays_
                .Include(e => e.SpaUsers)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employeePay == null)
            {
                return NotFound();
            }

            return View(employeePay);
        }

        // GET: EmployeePays/Create
        public IActionResult Create()
        {
            ViewData["SpaUsersId"] = new SelectList(_context.SpaUsers, "spaUserGuid", "FirstName");
            return View();
        }

        // POST: EmployeePays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SpaUsersId,GrossPay,CommisionPerJob,Status")] EmployeePay employeePay)
        {
            if (ModelState.IsValid)
            {
                employeePay.Id = Guid.NewGuid();
                _context.Add(employeePay);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpaUsersId"] = new SelectList(_context.SpaUsers, "spaUserGuid", "FirstName", employeePay.SpaUsersId);
            return View(employeePay);
        }

        // GET: EmployeePays/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePay = await _context.EmployeePays_.SingleOrDefaultAsync(m => m.Id == id);
            if (employeePay == null)
            {
                return NotFound();
            }
            ViewData["SpaUsersId"] = new SelectList(_context.SpaUsers, "spaUserGuid", "FirstName", employeePay.SpaUsersId);
            return View(employeePay);
        }

        // POST: EmployeePays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SpaUsersId,GrossPay,CommisionPerJob,Status")] EmployeePay employeePay)
        {
            if (id != employeePay.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeePay);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeePayExists(employeePay.Id))
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
            ViewData["SpaUsersId"] = new SelectList(_context.SpaUsers, "spaUserGuid", "FirstName", employeePay.SpaUsersId);
            return View(employeePay);
        }

        // GET: EmployeePays/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employeePay = await _context.EmployeePays_
                .Include(e => e.SpaUsers)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (employeePay == null)
            {
                return NotFound();
            }

            return View(employeePay);
        }

        // POST: EmployeePays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var employeePay = await _context.EmployeePays_.SingleOrDefaultAsync(m => m.Id == id);
            _context.EmployeePays_.Remove(employeePay);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeePayExists(Guid id)
        {
            return _context.EmployeePays_.Any(e => e.Id == id);
        }
    }
}

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
    public class CrmIssueCategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CrmIssueCategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CrmIssueCategories
        public async Task<IActionResult> Index()
        {
            return View(await _context.CrmIssueCategory.ToListAsync());
        }

        // GET: CrmIssueCategories/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crmIssueCategory = await _context.CrmIssueCategory
                .SingleOrDefaultAsync(m => m.Id == id);
            if (crmIssueCategory == null)
            {
                return NotFound();
            }

            return View(crmIssueCategory);
        }

        // GET: CrmIssueCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CrmIssueCategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,Code,Status")] CrmIssueCategory crmIssueCategory)
        {
            if (ModelState.IsValid)
            {
                crmIssueCategory.Id = Guid.NewGuid();
                _context.Add(crmIssueCategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(crmIssueCategory);
        }

        // GET: CrmIssueCategories/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crmIssueCategory = await _context.CrmIssueCategory.SingleOrDefaultAsync(m => m.Id == id);
            if (crmIssueCategory == null)
            {
                return NotFound();
            }
            return View(crmIssueCategory);
        }

        // POST: CrmIssueCategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,Code,Status")] CrmIssueCategory crmIssueCategory)
        {
            if (id != crmIssueCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crmIssueCategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrmIssueCategoryExists(crmIssueCategory.Id))
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
            return View(crmIssueCategory);
        }

        // GET: CrmIssueCategories/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crmIssueCategory = await _context.CrmIssueCategory
                .SingleOrDefaultAsync(m => m.Id == id);
            if (crmIssueCategory == null)
            {
                return NotFound();
            }

            return View(crmIssueCategory);
        }

        // POST: CrmIssueCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var crmIssueCategory = await _context.CrmIssueCategory.SingleOrDefaultAsync(m => m.Id == id);
            _context.CrmIssueCategory.Remove(crmIssueCategory);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrmIssueCategoryExists(Guid id)
        {
            return _context.CrmIssueCategory.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Spa_Management.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Spa_Management.Controllers
{
    public class BankUserRolesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOperations;
        private readonly UserManager<ApplicationUser> _userManager;
        public BankUserRolesController(ApplicationDbContext context, IDbOperations dbOperations, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dbOperations = dbOperations;
            _userManager = userManager;
        }

        // GET: BankUserRoles
        public async Task<IActionResult> Index()
        {
            return View(await _context.tbBankUserRoles.ToListAsync());
        }

        // GET: BankUserRoles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankUserRoles = await _context.tbBankUserRoles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbBankUserRoles == null)
            {
                return NotFound();
            }

            return View(tbBankUserRoles);
        }

        // GET: BankUserRoles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankUserRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BankId,RoleName,DateAdded")] tbBankUserRoles tbBankUserRoles)
        {
            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
               // me.
                if (ModelState.IsValid)
                {
                    await _dbOperations.AddBankRole(tbBankUserRoles);
                    //tbBankUserRoles.Id = Guid.NewGuid();
                    //_context.Add(tbBankUserRoles);
                    //await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                return View(tbBankUserRoles);
            }
            catch (Exception)
            {

                throw;
            }
           
        }

        // GET: BankUserRoles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankUserRoles = await _context.tbBankUserRoles.SingleOrDefaultAsync(m => m.Id == id);
            if (tbBankUserRoles == null)
            {
                return NotFound();
            }
            return View(tbBankUserRoles);
        }

        // POST: BankUserRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BankId,RoleName,DateAdded")] tbBankUserRoles tbBankUserRoles)
        {
            if (id != tbBankUserRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBankUserRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBankUserRolesExists(tbBankUserRoles.Id))
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
            return View(tbBankUserRoles);
        }

        // GET: BankUserRoles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankUserRoles = await _context.tbBankUserRoles
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbBankUserRoles == null)
            {
                return NotFound();
            }

            return View(tbBankUserRoles);
        }

        // POST: BankUserRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbBankUserRoles = await _context.tbBankUserRoles.SingleOrDefaultAsync(m => m.Id == id);
            _context.tbBankUserRoles.Remove(tbBankUserRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbBankUserRolesExists(Guid id)
        {
            return _context.tbBankUserRoles.Any(e => e.Id == id);
        }
    }
}

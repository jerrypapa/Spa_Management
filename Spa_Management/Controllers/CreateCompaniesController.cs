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
    public class CreateCompaniesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOperations;
        private readonly UserManager<ApplicationUser> _userManager;
        public CreateCompaniesController(ApplicationDbContext context, IDbOperations dbOperations, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dbOperations = dbOperations;
            _userManager = userManager;
        }


        // GET: CreateCompanies
        public async Task<IActionResult> Index()
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            //  var compDetails=_context.TbCompanies.FirstOrDefault(c=>c.compGuid==me.)

            var myList = await _context.TbCompanies.Include(k => k.tbCompanyUsers.Where(u => u.compGuid == me.compUserGuid)).ToListAsync();
            return View(myList);
        }

        // GET: CreateCompanies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCompanies = await _context.TbCompanies
                .SingleOrDefaultAsync(m => m.compGuid == id);
            if (tbCompanies == null)
            {
                return NotFound();
            }

            return View(tbCompanies);
        }

        // GET: CreateCompanies/Create
        public async Task<IActionResult> Create()
        {

            var me = await _userManager.GetUserAsync(HttpContext.User);
            //  var compDetails=_context.TbCompanies.FirstOrDefault(c=>c.compGuid==me.)

            var myList = await _context.TbCompanies.Include(k => k.tbCompanyUsers.Where(u => u.compGuid == me.compUserGuid)).ToListAsync();
            return View(myList);
        }
              // POST: CreateCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("compGuid,registeredBy,compName,email,pysicalLoc,postalAddress,PinNo,RegCertNo,contact,incDate,incNum,regDate,BankCode,branchCode,accNum,status")] tbCompanies tbCompanies)
        {
            if (ModelState.IsValid)
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                tbCompanies.registeredBy = me.indGuid.ToString();
                await _dbOperations.RegisterCompany(tbCompanies);

                //tbCompanies.compGuid = Guid.NewGuid();
                //_context.Add(tbCompanies);
                //await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbCompanies);
        }

        // GET: CreateCompanies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCompanies = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compGuid == id);
            if (tbCompanies == null)
            {
                return NotFound();
            }
            return View(tbCompanies);
        }

        // POST: CreateCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("compGuid,registeredBy,compName,email,pysicalLoc,postalAddress,PinNo,RegCertNo,contact,incDate,incNum,regDate,BankCode,branchCode,accNum,status")] tbCompanies tbCompanies)
        {
            if (id != tbCompanies.compGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbCompanies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbCompaniesExists(tbCompanies.compGuid))
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
            return View(tbCompanies);
        }

        // GET: CreateCompanies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbCompanies = await _context.TbCompanies
                .SingleOrDefaultAsync(m => m.compGuid == id);
            if (tbCompanies == null)
            {
                return NotFound();
            }

            return View(tbCompanies);
        }

        // POST: CreateCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbCompanies = await _context.TbCompanies.SingleOrDefaultAsync(m => m.compGuid == id);
            _context.TbCompanies.Remove(tbCompanies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbCompaniesExists(Guid id)
        {
            return _context.TbCompanies.Any(e => e.compGuid == id);
        }
    }
}

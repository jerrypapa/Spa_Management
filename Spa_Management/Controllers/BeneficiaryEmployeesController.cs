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
    public class BeneficiaryEmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BeneficiaryEmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BeneficiaryEmployees
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbBeneficiaryEmployees.ToListAsync());
        }

        // GET: BeneficiaryEmployees/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficiaryEmployees = await _context.TbBeneficiaryEmployees
                .SingleOrDefaultAsync(m => m.userGuid == id);
            if (tbBeneficiaryEmployees == null)
            {
                return NotFound();
            }

            return View(tbBeneficiaryEmployees);
        }

        // GET: BeneficiaryEmployees/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BeneficiaryEmployees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("userGuid,institutionGuid,RoleId,designation,SirName,FirstName,MiddleName,LastName,contact,email,NationCode,dob,idType,idNumber,status,regDate")] tbBeneficiaryEmployees tbBeneficiaryEmployees)
        {
            if (ModelState.IsValid)
            {
                tbBeneficiaryEmployees.userGuid = Guid.NewGuid();
                _context.Add(tbBeneficiaryEmployees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbBeneficiaryEmployees);
        }

        // GET: BeneficiaryEmployees/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficiaryEmployees = await _context.TbBeneficiaryEmployees.SingleOrDefaultAsync(m => m.userGuid == id);
            if (tbBeneficiaryEmployees == null)
            {
                return NotFound();
            }
            return View(tbBeneficiaryEmployees);
        }

        // POST: BeneficiaryEmployees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("userGuid,institutionGuid,RoleId,designation,SirName,FirstName,MiddleName,LastName,contact,email,NationCode,dob,idType,idNumber,status,regDate")] tbBeneficiaryEmployees tbBeneficiaryEmployees)
        {
            if (id != tbBeneficiaryEmployees.userGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBeneficiaryEmployees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBeneficiaryEmployeesExists(tbBeneficiaryEmployees.userGuid))
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
            return View(tbBeneficiaryEmployees);
        }

        // GET: BeneficiaryEmployees/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficiaryEmployees = await _context.TbBeneficiaryEmployees
                .SingleOrDefaultAsync(m => m.userGuid == id);
            if (tbBeneficiaryEmployees == null)
            {
                return NotFound();
            }

            return View(tbBeneficiaryEmployees);
        }

        // POST: BeneficiaryEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbBeneficiaryEmployees = await _context.TbBeneficiaryEmployees.SingleOrDefaultAsync(m => m.userGuid == id);
            _context.TbBeneficiaryEmployees.Remove(tbBeneficiaryEmployees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbBeneficiaryEmployeesExists(Guid id)
        {
            return _context.TbBeneficiaryEmployees.Any(e => e.userGuid == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Microsoft.AspNetCore.Identity;

namespace Spa_Management.Views
{
    public class BankBranchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public BankBranchesController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _userManager = manager;
        }

        // GET: BankBranches
        public async Task<IActionResult> Index()
        {
           
            var me = await _userManager.GetUserAsync(HttpContext.User);
            var ApplicationDbContext = _context.TbBankBranches.Include(t => t.tbSystemBanks);
            if (User.IsInRole("BankAdmin"))
            {
                int? page = 1;
                var ApplicationDbContext1 = from m in _context.TbBankBranches
                                           select m;
                var bank = _context.TbBankUsers.FirstOrDefault(j => j.bankUserGuid == me.bankUserGuid).SystemBanksGuid;
                //return View(await _context.TbApplications.Where(y => y.compGuid == company).ToListAsync());
                ApplicationDbContext1 = ApplicationDbContext1.Where(y => y.SystemBanksGuid == bank).Include(t => t.tbSystemBanks);
                int pageSize = 400;
                return View(await PaginatedList<tbBankBranches>.CreateAsync(ApplicationDbContext1.AsNoTracking(), page ?? 1, pageSize));
            }
            else
            if (User.IsInRole("MasterAdmin"))
            {
                ApplicationDbContext = _context.TbBankBranches.Include(t => t.tbSystemBanks);
                return View(await ApplicationDbContext.ToListAsync());
            }
            return View(await ApplicationDbContext.ToListAsync());

        }

        // GET: BankBranches/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankBranches = await _context.TbBankBranches
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.BranchGuid == id);
            if (tbBankBranches == null)
            {
                return NotFound();
            }

            return View(tbBankBranches);
        }

        // GET: BankBranches/Create
        public IActionResult Create()
        {
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
            return View();
        }

        // POST: BankBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BranchGuid,SystemBanksGuid,branchCode,branchName,regDate,physicalLoc,adrress,BankCollectionAccount,status")] tbBankBranches tbBankBranches)
        {

            tbBankBranches.status = 0;
            tbBankBranches.regDate = DateTime.Now;
            tbBankBranches branches = await _context.TbBankBranches.SingleOrDefaultAsync(m => m.branchCode == tbBankBranches.branchCode
            && m.branchName == tbBankBranches.branchName);


            if (ModelState.IsValid)
            {
                if (branches != null)
                {
                    ModelState.AddModelError(string.Empty, "This branch already exists");
                    return View(tbBankBranches);
                }
                else
                {
                    tbBankBranches.BranchGuid = Guid.NewGuid();
                    _context.Add(tbBankBranches);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }           
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbBankBranches.SystemBanksGuid);
            return View(tbBankBranches);
        }

        // GET: BankBranches/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankBranches = await _context.TbBankBranches.SingleOrDefaultAsync(m => m.BranchGuid == id);
            if (tbBankBranches == null)
            {
                return NotFound();
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbBankBranches.SystemBanksGuid);
            return View(tbBankBranches);
        }

        // POST: BankBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BranchGuid,SystemBanksGuid,branchCode,branchName,regDate,physicalLoc,adrress,BankCollectionAccount,status")] tbBankBranches tbBankBranches)
        {
            if (id != tbBankBranches.BranchGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbBankBranches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBankBranchesExists(tbBankBranches.BranchGuid))
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
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbBankBranches.SystemBanksGuid);
            return View(tbBankBranches);
        }

        // GET: BankBranches/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBankBranches = await _context.TbBankBranches
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.BranchGuid == id);
            if (tbBankBranches == null)
            {
                return NotFound();
            }

            return View(tbBankBranches);
        }

        // POST: BankBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbBankBranches = await _context.TbBankBranches.SingleOrDefaultAsync(m => m.BranchGuid == id);
            _context.TbBankBranches.Remove(tbBankBranches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbBankBranchesExists(Guid id)
        {
            return _context.TbBankBranches.Any(e => e.BranchGuid == id);
        }
    }
}

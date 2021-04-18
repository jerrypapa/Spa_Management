using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Identity;
using Spa_Management.Interfaces;

namespace Spa_Management.Controllers
{
    public class SystemBanksController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        public SystemBanksController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: SystemBanks
        public async Task<IActionResult> Index()
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("BankAdmin") || User.IsInRole("BankUser"))
            {
                var bank = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == me.bankUserGuid);
                return View(await _context.TbSystemBanks.Where(k=>k.SystemBanksGuid == bank.SystemBanksGuid).ToListAsync());
            }
            else if(User.IsInRole("MasterAdmin"))
            {
                return View(await _context.TbSystemBanks.ToListAsync());
            }
            else
            {
                return View(await _context.TbSystemBanks.ToListAsync());
            }
            
        }

        // GET: SystemBanks/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSystemBanks = await _context.TbSystemBanks
                .SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
            if (tbSystemBanks == null)
            {
                return NotFound();
            }

            return View(tbSystemBanks);
        }
        public async Task<IActionResult> Users(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            //ViewData["BankGuid"] = id.Value;
            ViewData["BankGuid"] = id.Value;
            ViewData["BankName"] = _context.TbSystemBanks.FirstOrDefault(k => k.SystemBanksGuid == id).bankName;
            var users = await _context.TbBankUsers.Where(h => h.SystemBanksGuid == id).ToListAsync();
                //.SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
            if (users == null)
            {
                return NotFound();
            }
            List<ViewBankUsers> _CompUsers = new List<ViewBankUsers>();
            int i = 1;
            foreach (var a in users)
            {
                ViewBankUsers user = new ViewBankUsers()
                {
                    id = i++,
                    bankUserGuid = a.bankUserGuid,
                    Name = string.Format("{0} {1} {2}", a.SirName, a.FirstName, a.LastName),
                    contact = a.contact,
                    Email = a.email,
                    idNumber = a.idNumber,
                    Role = await _dbOps.GetUserRole(a.bankUserGuid, 2),
                    status = a.status
                };
                _CompUsers.Add(user);
            }
            return View(_CompUsers);
            //return View(users);
        }
        // GET: SystemBanks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SystemBanks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SystemBanksGuid,bankCode,bankName,regDate,AllowAutoGene,BondProcessDays,MaximumSecurityLimit,OveralSecuringLimit,status")] tbSystemBanks tbSystemBanks,string AllowAutoGene)
        {
            var allowed = AllowAutoGene;
            tbSystemBanks.status = 0;
            tbSystemBanks.AllowAutoGene = AllowAutoGene; 
            tbSystemBanks.regDate = DateTime.Now;
            tbSystemBanks.LimitBalance = tbSystemBanks.OveralSecuringLimit;
            tbSystemBanks bankziko = await _context.TbSystemBanks.SingleOrDefaultAsync(m => m.bankCode == tbSystemBanks.bankCode
            && m.bankName == tbSystemBanks.bankName);

            if (ModelState.IsValid)
            {
                if(bankziko != null)
                {
                    ModelState.AddModelError(string.Empty, "This bank already exists");
                    return View(tbSystemBanks);
                }
                else
                {
                    tbSystemBanks.SystemBanksGuid = Guid.NewGuid();
                    _context.Add(tbSystemBanks);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }            
            }
            return View(tbSystemBanks);
        }

        // GET: SystemBanks/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSystemBanks = await _context.TbSystemBanks.SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
            if (tbSystemBanks == null)
            {
                return NotFound();
            }
            return View(tbSystemBanks);
        }

        // POST: SystemBanks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("SystemBanksGuid,bankCode,bankName,regDate,AllowAutoGene,BondProcessDays,MaximumSecurityLimit,OveralSecuringLimit,status")] tbSystemBanks tbSystemBanks, string AllowAutoGene)
        {
            if (id != tbSystemBanks.SystemBanksGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tbSystemBanks.AllowAutoGene = AllowAutoGene;
                    tbSystemBanks.LimitBalance = tbSystemBanks.OveralSecuringLimit;
                    _context.Update(tbSystemBanks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbSystemBanksExists(tbSystemBanks.SystemBanksGuid))
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
            return View(tbSystemBanks);
        }

        // GET: SystemBanks/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbSystemBanks = await _context.TbSystemBanks
                .SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
            if (tbSystemBanks == null)
            {
                return NotFound();
            }

            return View(tbSystemBanks);
        }

        // POST: SystemBanks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbSystemBanks = await _context.TbSystemBanks.SingleOrDefaultAsync(m => m.SystemBanksGuid == id);
            _context.TbSystemBanks.Remove(tbSystemBanks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbSystemBanksExists(Guid id)
        {
            return _context.TbSystemBanks.Any(e => e.SystemBanksGuid == id);
        }
    }
}

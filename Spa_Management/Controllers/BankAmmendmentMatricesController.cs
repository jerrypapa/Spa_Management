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
    public class BankAmmendmentMatricesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;

        public BankAmmendmentMatricesController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: BankAmmendmentMatrices
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                //var bankUserId = _context.Users.FirstOrDefault(f => f.UserName == User.Identity.Name).bankUserGuid;
                // var bank = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == bankUserId);
                var ApplicationDbContext = _context.BankAmmendmentMatrices;//.Where(h => h.SystemBanksGuid == bank.SystemBanksGuid).Include(t => t.tbSystemBanks);
                return View(await ApplicationDbContext.Include(t => t.tbSystemBanks).ToListAsync());
            }
            return View(await _context.BankAmmendmentMatrices.Include(t => t.tbSystemBanks).ToListAsync());

            //var ApplicationDbContext = _context.BankAmmendmentMatrices.Include(b => b.tbSystemBanks);
            //return View(await ApplicationDbContext.ToListAsync());
        }
        //[HttpGet]
        //public IActionResult Terms()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult AmmendTerms()
        {
            return View();
        }
        // GET: BankAmmendmentMatrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAmmendmentMatrices = await _context.BankAmmendmentMatrices
                .Include(b => b.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bankAmmendmentMatrices == null)
            {
                return NotFound();
            }

            return View(bankAmmendmentMatrices);
        }

        // GET: BankAmmendmentMatrices/Create
        public IActionResult Create()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
                ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
                return View();
            }
            return new ForbidResult();
            //ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene");
            //return View();
        }

        // POST: BankAmmendmentMatrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SystemBanksGuid,perCom,currency,FlatRate,period,status")] BankAmmendmentMatrices bankAmmendmentMatrices)
        {
            try
            {
                if (User.IsInRole("MasterAdmin"))
                {
                    // Get bank of admin
                    //var bankUserId = _context.Users.FirstOrDefault(f => f.UserName == User.Identity.Name).bankUserGuid;
                    // var bankId = _context.TbSystemBanks.FirstOrDefault(h => h.SystemBanksGuid == bankUserId).SystemBanksGuid;
                    // Check Ranges
                    // tbComMatrices.SystemBanksGuid = bankId;
                    bankAmmendmentMatrices.status = 0;

                    //var mat = _context.TbComMatrices.FirstOrDefault(g => g.SystemBanksGuid == tbComMatrices.SystemBanksGuid && g.currency == tbComMatrices.currency 
                    //&& (g.from <= tbComMatrices.from  && g.to >= tbComMatrices.from));

                    var mat = _context.BankAmmendmentMatrices.FirstOrDefault(g => g.SystemBanksGuid == bankAmmendmentMatrices.SystemBanksGuid && g.currency == bankAmmendmentMatrices.currency);

                    if ((mat is null))
                    {
                        // Save
                        if (ModelState.IsValid)
                        {
                            _context.Add(bankAmmendmentMatrices);
                            await _context.SaveChangesAsync();
                            await _dbOps.AuditOperation(User.Identity.Name, "BankAmmenmentMatrices/Create", "Added a new Bank Ammendment Matrix " + bankAmmendmentMatrices.Id.ToString(), "", "BankAmmendmentComMatrices");
                            return RedirectToAction(nameof(Index));
                        }
                        else
                        {
                            var valids = ModelState.Keys
                            .SelectMany(key => ModelState[key].Errors.Select(x => x.ErrorMessage))
                            .ToList();
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "The Range Values are Overriding");
                    }


                }
                else
                {
                    return new ForbidResult();
                }

            }
            catch (Exception ex)
            {
                _dbOps.LogError("BankAmmendmentMatrix/Create", "Adding new Bank ammendment MAtrix", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", bankAmmendmentMatrices.SystemBanksGuid);
            ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", bankAmmendmentMatrices.currency);
            return View(bankAmmendmentMatrices);
            //if (ModelState.IsValid)
            //{
            //    _context.Add(bankAmmendmentMatrices);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene", bankAmmendmentMatrices.SystemBanksGuid);
            //return View(bankAmmendmentMatrices);
        }

        // GET: BankAmmendmentMatrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAmmendmentMatrices = await _context.BankAmmendmentMatrices.SingleOrDefaultAsync(m => m.Id == id);
            if (bankAmmendmentMatrices == null)
            {
                return NotFound();
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene", bankAmmendmentMatrices.SystemBanksGuid);
            return View(bankAmmendmentMatrices);
        }

        // POST: BankAmmendmentMatrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SystemBanksGuid,perCom,currency,FlatRate,period,status")] BankAmmendmentMatrices bankAmmendmentMatrices)
        {
            if (id != bankAmmendmentMatrices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bankAmmendmentMatrices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankAmmendmentMatricesExists(bankAmmendmentMatrices.Id))
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
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene", bankAmmendmentMatrices.SystemBanksGuid);
            return View(bankAmmendmentMatrices);
        }

        // GET: BankAmmendmentMatrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankAmmendmentMatrices = await _context.BankAmmendmentMatrices
                .Include(b => b.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bankAmmendmentMatrices == null)
            {
                return NotFound();
            }

            return View(bankAmmendmentMatrices);
        }

        // POST: BankAmmendmentMatrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bankAmmendmentMatrices = await _context.BankAmmendmentMatrices.SingleOrDefaultAsync(m => m.Id == id);
            _context.BankAmmendmentMatrices.Remove(bankAmmendmentMatrices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankAmmendmentMatricesExists(int id)
        {
            return _context.BankAmmendmentMatrices.Any(e => e.Id == id);
        }
    }
}

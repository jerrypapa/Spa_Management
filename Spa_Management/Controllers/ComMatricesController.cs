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
    public class ComMatricesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;

        public ComMatricesController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: ComMatrices
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                //var bankUserId = _context.Users.FirstOrDefault(f => f.UserName == User.Identity.Name).bankUserGuid;
               // var bank = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == bankUserId);
                var ApplicationDbContext = _context.TbComMatrices;//.Where(h => h.SystemBanksGuid == bank.SystemBanksGuid).Include(t => t.tbSystemBanks);
                return View(await ApplicationDbContext.Include(t => t.tbSystemBanks).ToListAsync());
            }
            return View(await _context.TbComMatrices.Include(t => t.tbSystemBanks).ToListAsync());
        }

        // GET: ComMatrices/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbComMatrices = await _context.TbComMatrices
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbComMatrices == null)
            {
                return NotFound();
            }

            return View(tbComMatrices);
        }

        // GET: ComMatrices/Create
        public IActionResult Create()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
                ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
                return View();
            }
            return new ForbidResult();
        }

        // POST: ComMatrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,currency,SystemBanksGuid,perCom,status,FlatRate,period")] tbComMatrices tbComMatrices)
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
                    tbComMatrices.status = 0;
                 
                        //var mat = _context.TbComMatrices.FirstOrDefault(g => g.SystemBanksGuid == tbComMatrices.SystemBanksGuid && g.currency == tbComMatrices.currency 
                        //&& (g.from <= tbComMatrices.from  && g.to >= tbComMatrices.from));

                        var mat = _context.TbComMatrices.FirstOrDefault(g => g.SystemBanksGuid == tbComMatrices.SystemBanksGuid && g.currency == tbComMatrices.currency);
                   
                        if ((mat is null))
                        {
                            // Save
                            if (ModelState.IsValid)
                            {
                                _context.Add(tbComMatrices);
                                await _context.SaveChangesAsync();
                                await _dbOps.AuditOperation(User.Identity.Name, "ComMatrices/Create", "Added a new Bank Matrix " + tbComMatrices.Id.ToString(), "", "ComMatrices");
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
                _dbOps.LogError("ComMatrices/Create", "Adding new Commision MAtrix", "", ex.Message.ToString(), ex.InnerException is null ? "": ex.InnerException.ToString());
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbComMatrices.SystemBanksGuid);
            ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", tbComMatrices.currency);
            return View(tbComMatrices);
        }

        // GET: ComMatrices/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (User.IsInRole("MasterAdmin"))
            {

            if (id == null)
            {
                return NotFound();
            }

            var tbComMatrices = await _context.TbComMatrices.SingleOrDefaultAsync(m => m.Id == id);
            if (tbComMatrices == null)
            {
                return NotFound();
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbComMatrices.SystemBanksGuid);
                ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", tbComMatrices.currency);
                return View(tbComMatrices);
            }
            return new ForbidResult();
        }

        // POST: ComMatrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,currency,SystemBanksGuid,perCom,status,FlatRate,period")] tbComMatrices tbComMatrices)
        {
            if (User.IsInRole("MasterAdmin"))
            {

                if (id != tbComMatrices.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        //if (tbComMatrices.to > tbComMatrices.from)
                        //{
                            _context.Update(tbComMatrices);
                            await _context.SaveChangesAsync();
                      //  }
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!tbComMatricesExists(tbComMatrices.Id))
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
                ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbComMatrices.SystemBanksGuid);
                ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", tbComMatrices.currency);
                return View(tbComMatrices);
            }
            return new ForbidResult();
        }

        // GET: ComMatrices/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbComMatrices = await _context.TbComMatrices
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbComMatrices == null)
            {
                return NotFound();
            }

            return View(tbComMatrices);
        }

        // POST: ComMatrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbComMatrices = await _context.TbComMatrices.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbComMatrices.Remove(tbComMatrices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbComMatricesExists(int id)
        {
            return _context.TbComMatrices.Any(e => e.Id == id);
        }
    }
}

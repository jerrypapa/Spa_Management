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
    public class TradePawaCommissionMatricesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;


        public TradePawaCommissionMatricesController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: TradePawaCommissionMatrices
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                //var bankUserId = _context.Users.FirstOrDefault(f => f.UserName == User.Identity.Name).bankUserGuid;
                // var bank = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == bankUserId);
                var ApplicationDbContext = _context.TradePawaMatrix;

                return View(await _context.TradePawaMatrix.ToListAsync());
            }
            return View(await _context.TradePawaMatrix.ToListAsync());
            // return View(await _context.TradePawaMatrix.ToListAsync());
        }

        // GET: TradePawaCommissionMatrices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradePawaCommissionMatrix = await _context.TradePawaMatrix
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tradePawaCommissionMatrix == null)
            {
                return NotFound();
            }

            return View(tradePawaCommissionMatrix);
        }

        // GET: TradePawaCommissionMatrices/Create
        public IActionResult Create()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
                return View();
            }
            return new ForbidResult();
        }

        // POST: TradePawaCommissionMatrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ammendment,MakerId,CheckerId,from,to,perCom,currency,FlatRate,period,status")] TradePawaCommissionMatrix tradePawaCommissionMatrix)
        {
            try
            {
                if (User.IsInRole("MasterAdmin"))
                {
                    tradePawaCommissionMatrix.status = 0;
                    tradePawaCommissionMatrix.Id = Guid.NewGuid();
                    tradePawaCommissionMatrix.MakerId = Guid.Empty;
                    tradePawaCommissionMatrix.CheckerId = Guid.Empty;

                    // Save
                    if (ModelState.IsValid)
                        {
                            _context.Add(tradePawaCommissionMatrix);
                            await _context.SaveChangesAsync();
                            await _dbOps.AuditOperation(User.Identity.Name, "TradePawaMatrix/Create", "Added a new TradePawa Matrix " + tradePawaCommissionMatrix.Id.ToString(), "", "ComMatrices");
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
                    return new ForbidResult();
                }

            }
            catch (Exception ex)
            {
                _dbOps.LogError("ComMatrices/Create", "Adding new Commision MAtrix", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
            }
            ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", tradePawaCommissionMatrix.currency);
            return View(tradePawaCommissionMatrix);

        }

        // GET: TradePawaCommissionMatrices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradePawaCommissionMatrix = await _context.TradePawaMatrix.SingleOrDefaultAsync(m => m.Id == id);
            if (tradePawaCommissionMatrix == null)
            {
                return NotFound();
            }
            return View(tradePawaCommissionMatrix);
        }

        // POST: TradePawaCommissionMatrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Ammendment,MakerId,CheckerId,from,to,perCom,currency,FlatRate,period,status")] TradePawaCommissionMatrix tradePawaCommissionMatrix)
        {
            if (id != tradePawaCommissionMatrix.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tradePawaCommissionMatrix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TradePawaCommissionMatrixExists(tradePawaCommissionMatrix.Id))
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
            return View(tradePawaCommissionMatrix);
        }

        // GET: TradePawaCommissionMatrices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tradePawaCommissionMatrix = await _context.TradePawaMatrix
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tradePawaCommissionMatrix == null)
            {
                return NotFound();
            }

            return View(tradePawaCommissionMatrix);
        }

        // POST: TradePawaCommissionMatrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tradePawaCommissionMatrix = await _context.TradePawaMatrix.SingleOrDefaultAsync(m => m.Id == id);
            _context.TradePawaMatrix.Remove(tradePawaCommissionMatrix);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TradePawaCommissionMatrixExists(Guid id)
        {
            return _context.TradePawaMatrix.Any(e => e.Id == id);
        }
    }
}

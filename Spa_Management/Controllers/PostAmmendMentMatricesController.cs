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
using Spa_Management.Interfaces;

namespace Spa_Management.Controllers
{
    public class PostAmmendMentMatricesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostAmmendMentMatricesController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
        }

        // GET: PostAmmendMentMatrices
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                //var bankUserId = _context.Users.FirstOrDefault(f => f.UserName == User.Identity.Name).bankUserGuid;
                // var bank = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == bankUserId);
                var ApplicationDbContext = _context.PostAmmendMentMatrix;
                return View(await _context.PostAmmendMentMatrix.ToListAsync());//.Where(h => h.SystemBanksGuid == bank.SystemBanksGuid).Include(t => t.tbSystemBanks);
                                                                               //  return View(await ApplicationDbContext.Include(t => t.tbSystemBanks).ToListAsync());
            }
          //  return View(await _context.BankAmmendmentMatrices.Include(t => t.tbSystemBanks).ToListAsync());
            return View(await _context.PostAmmendMentMatrix.ToListAsync());
        }

        // GET: PostAmmendMentMatrices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postAmmendMentMatrix = await _context.PostAmmendMentMatrix
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postAmmendMentMatrix == null)
            {
                return NotFound();
            }

            return View(postAmmendMentMatrix);
        }

        // GET: PostAmmendMentMatrices/Create
        public IActionResult Create()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency");
                return View();
            }
            return new ForbidResult();
        }

        // POST: PostAmmendMentMatrices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MakerId,CheckerId,from,to,perCom,currency,FlatRate,period,status")] PostAmmendMentMatrix postAmmendMentMatrix)
        {
            try
            {
                if (User.IsInRole("MasterAdmin"))
                {

                    postAmmendMentMatrix.status = 0;

                        if (ModelState.IsValid)
                        {
                            _context.Add(postAmmendMentMatrix);
                            await _context.SaveChangesAsync();
                            await _dbOps.AuditOperation(User.Identity.Name, "TradePawaAmmendmentMatrix/Create", "Added a new TradePawa Ammendment Matrix " + postAmmendMentMatrix.Id.ToString(), "", "TradePawaAmmendmentMatrix");
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
                _dbOps.LogError("TradePawaAmmendmentMatrix/Create", "Adding new TradePawa ammendment MAtrix", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
            }
            ViewData["currency"] = new SelectList(_context.TbCurrencies, "currency", "currency", postAmmendMentMatrix.currency);
            return View(postAmmendMentMatrix);
            //if (ModelState.IsValid)
            //{
            //    postAmmendMentMatrix.Id = Guid.NewGuid();
            //    _context.Add(postAmmendMentMatrix);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //return View(postAmmendMentMatrix);
        }

        // GET: PostAmmendMentMatrices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postAmmendMentMatrix = await _context.PostAmmendMentMatrix.SingleOrDefaultAsync(m => m.Id == id);
            if (postAmmendMentMatrix == null)
            {
                return NotFound();
            }
            return View(postAmmendMentMatrix);
        }

        // POST: PostAmmendMentMatrices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,MakerId,CheckerId,from,to,perCom,currency,FlatRate,period,status")] PostAmmendMentMatrix postAmmendMentMatrix)
        {
            if (id != postAmmendMentMatrix.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(postAmmendMentMatrix);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PostAmmendMentMatrixExists(postAmmendMentMatrix.Id))
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
            return View(postAmmendMentMatrix);
        }

        // GET: PostAmmendMentMatrices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var postAmmendMentMatrix = await _context.PostAmmendMentMatrix
                .SingleOrDefaultAsync(m => m.Id == id);
            if (postAmmendMentMatrix == null)
            {
                return NotFound();
            }

            return View(postAmmendMentMatrix);
        }

        // POST: PostAmmendMentMatrices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var postAmmendMentMatrix = await _context.PostAmmendMentMatrix.SingleOrDefaultAsync(m => m.Id == id);
            _context.PostAmmendMentMatrix.Remove(postAmmendMentMatrix);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PostAmmendMentMatrixExists(Guid id)
        {
            return _context.PostAmmendMentMatrix.Any(e => e.Id == id);
        }
    }
}

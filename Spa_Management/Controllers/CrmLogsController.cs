using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Spa_Management.Interfaces;

namespace Spa_Management.Controllers
{
    public class CrmLogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        private static IHostingEnvironment _env;

        public CrmLogsController(ApplicationDbContext context, IHostingEnvironment hosting,
            IDbOperations dbOps, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
            _env = hosting;
        }

        // GET: CrmLogs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CrmLogs.ToListAsync());
        }

        // GET: CrmLogs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            ViewData["IssueCategory"] = new SelectList(_context.CrmIssueCategory, "Code", "Description");
            var crmLogs = await _context.CrmLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (crmLogs == null)
            {
                return NotFound();
            }
            
            return View(crmLogs);
        }

        // GET: CrmLogs/Create
        public IActionResult Create()
        {
           
                var data = _context.CrmIssueCategory;
                ViewData["IssueCategory"] = new SelectList(_context.CrmIssueCategory, "Code", "Description");
                //  ViewData["appliedBy"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).FirstName;
                //  ViewData["ApplicantAdd"] = _context.TbCompanyUsers.SingleOrDefault(m => m.compUserGuid == me.compUserGuid).pysicalLoc;
            
            return View();
        }

        // POST: CrmLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,CategoryCode,DateLogged,DateResolved,Status,UserId,EntityId,UserEmail,UserPhoneNumber,EntityCategoryCode")] CrmLogs crmLogs)
        {
            if (ModelState.IsValid)
            {
              

                var me = await _userManager.GetUserAsync(HttpContext.User);

                if (User.IsInRole("BankUser")||User.IsInRole("BankAdmin"))
                {
                    var bank = _context.TbBankUsers.FirstOrDefault(o => o.bankUserGuid == me.bankUserGuid);
                    crmLogs.UserId = me.bankUserGuid;
                    crmLogs.EntityId = bank.SystemBanksGuid;
                    crmLogs.UserEmail = bank.email;
                    crmLogs.UserPhoneNumber = bank.contact;
                    //get user id
                }
                if (User.IsInRole("CompanyUser")||User.IsInRole("CompanyAdmin"))
                {
                    var company = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid);
                    crmLogs.UserId = me.compUserGuid;
                    crmLogs.EntityId = company.compGuid;
                    crmLogs.UserPhoneNumber = company.contact;
                    crmLogs.UserEmail = company.email;

                }
                
                var issueLoged = await _dbOps.LogCrm(crmLogs);
                if (issueLoged == true)
                {
                    //Trgigger mail sending
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    //Show Error
                }
                //crmLogs.Id = Guid.NewGuid();
                //_context.Add(crmLogs);
                //await _context.SaveChangesAsync();
                
            }
            return View(crmLogs);
        }

        // GET: CrmLogs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crmLogs = await _context.CrmLogs.SingleOrDefaultAsync(m => m.Id == id);
            if (crmLogs == null)
            {
                return NotFound();
            }
            return View(crmLogs);
        }

        // POST: CrmLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Description,CategoryCode,DateLogged,DateResolved,Status,UserId,EntityId,UserEmail,UserPhoneNumber,EntityCategoryCode")] CrmLogs crmLogs)
        {
            if (id != crmLogs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(crmLogs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CrmLogsExists(crmLogs.Id))
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
            return View(crmLogs);
        }

        // GET: CrmLogs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var crmLogs = await _context.CrmLogs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (crmLogs == null)
            {
                return NotFound();
            }

            return View(crmLogs);
        }

        // POST: CrmLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var crmLogs = await _context.CrmLogs.SingleOrDefaultAsync(m => m.Id == id);
            _context.CrmLogs.Remove(crmLogs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CrmLogsExists(Guid id)
        {
            return _context.CrmLogs.Any(e => e.Id == id);
        }
    }
}

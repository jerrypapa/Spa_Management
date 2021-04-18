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
    public class ApplicationReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApplicationReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ApplicationReports
        public async Task<IActionResult> Index()
        {
            var ApplicationDbContext = _context.TbApplications.Include(t => t.tbSystemBanks);
            return View(await ApplicationDbContext.ToListAsync());
        }

        // GET: ApplicationReports/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbApplications = await _context.TbApplications
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbApplications == null)
            {
                return NotFound();
            }

            return View(tbApplications);
        }

        // GET: ApplicationReports/Create
        public IActionResult Create()
        {
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene");
            return View();
        }

        // POST: ApplicationReports/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CRBGuid,indGuid,compGuid,appliedBy,appDate,SystemBanksGuid,BranchGuid,amount,approvedAmount,BankComm,status,BidBondDocStatus,ClientPreviewApproved,ClientPrinted,QrCode,BidBondPath,PIN,Purchaser,approvalDate,comments,AcceptTerms,terms,expireDate,Details,ActionCode,currency,TenderPeriod,PrintCode,Period,tenderNo,bondStartDate,tenderDocs,approvedBy,checkedBy,checkerComments,checkerDate,CoreBankingReferenceNumber,PayRefrence,PayDate")] tbApplications tbApplications)
        {
            if (ModelState.IsValid)
            {
                tbApplications.CRBGuid = Guid.NewGuid();
                _context.Add(tbApplications);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene", tbApplications.SystemBanksGuid);
            return View(tbApplications);
        }

        // GET: ApplicationReports/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbApplications = await _context.TbApplications.SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbApplications == null)
            {
                return NotFound();
            }
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene", tbApplications.SystemBanksGuid);
            return View(tbApplications);
        }

        // POST: ApplicationReports/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CRBGuid,indGuid,compGuid,appliedBy,appDate,SystemBanksGuid,BranchGuid,amount,approvedAmount,BankComm,status,BidBondDocStatus,ClientPreviewApproved,ClientPrinted,QrCode,BidBondPath,PIN,Purchaser,approvalDate,comments,AcceptTerms,terms,expireDate,Details,ActionCode,currency,TenderPeriod,PrintCode,Period,tenderNo,bondStartDate,tenderDocs,approvedBy,checkedBy,checkerComments,checkerDate,CoreBankingReferenceNumber,PayRefrence,PayDate")] tbApplications tbApplications)
        {
            if (id != tbApplications.CRBGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbApplications);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbApplicationsExists(tbApplications.CRBGuid))
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
            ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "AllowAutoGene", tbApplications.SystemBanksGuid);
            return View(tbApplications);
        }

        // GET: ApplicationReports/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbApplications = await _context.TbApplications
                .Include(t => t.tbSystemBanks)
                .SingleOrDefaultAsync(m => m.CRBGuid == id);
            if (tbApplications == null)
            {
                return NotFound();
            }

            return View(tbApplications);
        }

        // POST: ApplicationReports/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbApplications = await _context.TbApplications.SingleOrDefaultAsync(m => m.CRBGuid == id);
            _context.TbApplications.Remove(tbApplications);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbApplicationsExists(Guid id)
        {
            return _context.TbApplications.Any(e => e.CRBGuid == id);
        }
    }
}

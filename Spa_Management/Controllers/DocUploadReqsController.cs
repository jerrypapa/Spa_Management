using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Controllers
{
	public class DocUploadReqsController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IDbOperations _dbOps;
		private readonly UserManager<ApplicationUser> _userManager;
		public DocUploadReqsController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> manager)
		{
			_context = context;
			_dbOps = dbOps;
			_userManager = manager;
		}

		// GET: DocUploadReqs
		public async Task<IActionResult> Index()
		{
			if (User.IsInRole("MasterAdmin") || User.IsInRole("BankAdmin"))
			{
				if (User.IsInRole("BankAdmin"))
				{
					//var ApplicationDbContext = _context.TbDocUploadReqs.Include(t => t.tbSystemBanks);
					var me = await _userManager.GetUserAsync(HttpContext.User);
					var bank = _context.TbBankUsers.FirstOrDefault(o => o.bankUserGuid == me.bankUserGuid).SystemBanksGuid;
					return View(await _context.TbDocUploadReqs.Where(y => y.SystemBanksGuid == bank).Include(t => t.tbSystemBanks).ToListAsync());
				}
				var ApplicationDbContext = _context.TbDocUploadReqs.Include(t => t.tbSystemBanks);
				return View(await ApplicationDbContext.ToListAsync());
			}
			return new ForbidResult();
		}

		// GET: DocUploadReqs/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbDocUploadReq = await _context.TbDocUploadReqs
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.docReqGuid == id);
			if (tbDocUploadReq == null)
			{
				return NotFound();
			}

			return View(tbDocUploadReq);
		}
		[Authorize(Roles = "BankAdmin")]
		// GET: DocUploadReqs/Create
		public IActionResult Create()
		{
			ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName");
			ViewData["TbDocTypes"] = new SelectList(_context.TbDocTypes, "Type", "Type");
			ViewData["Status"] = new List<SelectListItem>
						{
							new SelectListItem {Text = "Optional", Value = "1"},
							new SelectListItem {Text = "Madatory", Value = "2"}
						};
			return View();
		}

		// POST: DocUploadReqs/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Authorize(Roles = "BankAdmin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("docReqGuid,SystemBanksGuid,DocTypes,docName,Status")] tbDocUploadReq tbDocUploadReq)
		{
			var me = await _userManager.GetUserAsync(HttpContext.User);
			var bank = _context.TbBankUsers.FirstOrDefault(o => o.bankUserGuid == me.bankUserGuid).SystemBanksGuid;
			tbDocUploadReq.SystemBanksGuid = bank;
			if (ModelState.IsValid)
			{
				if (await _context.TbDocUploadReqs.FirstOrDefaultAsync(c => c.SystemBanksGuid == bank && c.docName == tbDocUploadReq.docName) == null)
				{
					tbDocUploadReq.docReqGuid = Guid.NewGuid();
					_context.Add(tbDocUploadReq);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				ModelState.AddModelError("", "Document type already added");
			}
			ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbDocUploadReq.SystemBanksGuid);
			ViewData["TbDocTypes"] = new SelectList(_context.TbDocTypes, "Type", "Type", tbDocUploadReq.DocTypes);
			ViewData["Status"] = new List<SelectListItem>
						{
							new SelectListItem {Text = "Optional", Value = "1"},
							new SelectListItem {Text = "Madatory", Value = "2"}
						};
			return View(tbDocUploadReq);
		}
		[Authorize(Roles = "BankAdmin")]
		// GET: DocUploadReqs/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbDocUploadReq = await _context.TbDocUploadReqs.SingleOrDefaultAsync(m => m.docReqGuid == id);
			if (tbDocUploadReq == null)
			{
				return NotFound();
			}
			ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbDocUploadReq.SystemBanksGuid);
			ViewData["TbDocTypes"] = new SelectList(_context.TbDocTypes, "Type", "Type", tbDocUploadReq.DocTypes);
			ViewData["Status"] = new List<SelectListItem>
						{
							new SelectListItem {Text = "Optional", Value = "1"},
							new SelectListItem {Text = "Madatory", Value = "2"}
						};
			return View(tbDocUploadReq);
		}

		// POST: DocUploadReqs/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[Authorize(Roles = "BankAdmin")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("docReqGuid,SystemBanksGuid,docName,Status")] tbDocUploadReq tbDocUploadReq)
		{
			if (id != tbDocUploadReq.docReqGuid)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(tbDocUploadReq);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!tbDocUploadReqExists(tbDocUploadReq.docReqGuid))
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
			ViewData["SystemBanksGuid"] = new SelectList(_context.TbSystemBanks, "SystemBanksGuid", "bankName", tbDocUploadReq.SystemBanksGuid);
			ViewData["TbDocTypes"] = new SelectList(_context.TbDocTypes, "Type", "Type", tbDocUploadReq.DocTypes);
			ViewData["Status"] = new List<SelectListItem>
						{
							new SelectListItem {Text = "Optional", Value = "1"},
							new SelectListItem {Text = "Madatory", Value = "2"}
						};
			return View(tbDocUploadReq);
		}
		[Authorize(Roles = "BankAdmin")]
		// GET: DocUploadReqs/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tbDocUploadReq = await _context.TbDocUploadReqs
				.Include(t => t.tbSystemBanks)
				.SingleOrDefaultAsync(m => m.docReqGuid == id);
			if (tbDocUploadReq == null)
			{
				return NotFound();
			}

			return View(tbDocUploadReq);
		}

		// POST: DocUploadReqs/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var tbDocUploadReq = await _context.TbDocUploadReqs.SingleOrDefaultAsync(m => m.docReqGuid == id);
			_context.TbDocUploadReqs.Remove(tbDocUploadReq);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool tbDocUploadReqExists(Guid id)
		{
			return _context.TbDocUploadReqs.Any(e => e.docReqGuid == id);
		}
	}
}

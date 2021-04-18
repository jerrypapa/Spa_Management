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
using Spa_Management.Operations;

namespace Spa_Management.Controllers
{
    public class BeneficialiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public BeneficialiesController(ApplicationDbContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _userManager = manager;
        }

        // GET: Beneficialies
        public async Task<IActionResult> Index()
        {
            try
            {
                var ApplicationDbContext = _context.TbBeneficialies;//.Include(t => t.tbIndivuduals);
                var me = await _userManager.GetUserAsync(HttpContext.User);
                if (User.IsInRole("Individual"))
                {
                    return View(await ApplicationDbContext.Where(y => y.indGuid == me.indGuid).ToListAsync());
                }
                if (User.IsInRole("CompanyUser"))
                {
                    return View(await ApplicationDbContext.Where(p => p.compUserGuid == me.compUserGuid).ToListAsync());
                }
                return View(await ApplicationDbContext.ToListAsync());
            }
            catch (Exception ex)
            {
            
                throw ex;
            }
         
        }

        // GET: Beneficialies/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficialies = await _context.TbBeneficialies
               // .Include(t => t.tbIndivuduals)
                .SingleOrDefaultAsync(m => m.benGuid == id);
            if (tbBeneficialies == null)
            {
                return NotFound();
            }

            return View(tbBeneficialies);
        }

        // GET: Beneficialies/Create
        public async Task<IActionResult> Create()
        {
            //ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName");
            var me = await   _userManager.GetUserAsync(HttpContext.User);

           // var model = new tbBeneficialies() { indGuid = me.indGuid };
            return View();
        }

        // POST: Beneficialies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]      
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("benGuid,indGuid,compUserGuid,SirName,FirstName,LastName,contact,email,physicalLoc,adrress")] tbBeneficialies tbBeneficialies)
        {
            try
            {
                //adminUserGuid
                if (ModelState.IsValid)
                {
                    var me = await _userManager.GetUserAsync(HttpContext.User);
                    if (User.IsInRole("Individual"))
                    {
                        tbBeneficialies.indGuid = me.indGuid;
                    }
                    if (User.IsInRole("CompanyUser"))
                    {
                        tbBeneficialies.compUserGuid = _context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compUserGuid;
                    }
                    if (User.IsInRole("MasterAdmin"))
                    {
                        tbBeneficialies.adminUserGuid = me.userGuid; //_context.TbCompanyUsers.FirstOrDefault(j => j.compUserGuid == me.compUserGuid).compUserGuid;
                    }
                    tbBeneficialies.FirstName = tbBeneficialies.SirName;
                    tbBeneficialies.LastName = tbBeneficialies.SirName;
                    tbBeneficialies.benGuid = Guid.NewGuid();


                    tbBeneficialies beneficialies = await _context.TbBeneficialies.SingleOrDefaultAsync(m => m.email == tbBeneficialies.email || m.contact == tbBeneficialies.contact);
                    if (beneficialies != null)
                    {
                        ModelState.AddModelError(string.Empty, "Beneficiary with Email "+ tbBeneficialies.email + " or contact " + tbBeneficialies.contact +"  already exists");
                        return View(tbBeneficialies);
                    }
                    else
                    {
                        _context.Add(tbBeneficialies);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                
                }
                ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbBeneficialies.indGuid);
                ViewData["compUserGuid"] = new SelectList(_context.TbCompanyUsers, "compUserGuid", "FirstName", tbBeneficialies.compUserGuid);
                return View(tbBeneficialies);

            }
            catch (Exception ex)
            {
                throw ex;
            }         
          
        }

        // GET: Beneficialies/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficialies = await _context.TbBeneficialies.SingleOrDefaultAsync(m => m.benGuid == id);

          
            if (tbBeneficialies == null)
            {
                return NotFound();
            }
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbBeneficialies.indGuid);
            ViewData["compUserGuid"] = new SelectList(_context.TbCompanyUsers, "compUserGuid", "FirstName", tbBeneficialies.compUserGuid);

            return View(tbBeneficialies);
        }

        // POST: Beneficialies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("benGuid,indGuid,compUserGuid,SirName,FirstName,LastName,contact,email,physicalLoc,adrress")] tbBeneficialies tbBeneficialies)
        {
            if (id != tbBeneficialies.benGuid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    tbBeneficialies.FirstName = tbBeneficialies.SirName;
                    tbBeneficialies.LastName = tbBeneficialies.SirName;
                    _context.Update(tbBeneficialies);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbBeneficialiesExists(tbBeneficialies.benGuid))
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
            ViewData["indGuid"] = new SelectList(_context.TbIndivuduals, "indGuid", "FirstName", tbBeneficialies.indGuid);
            ViewData["compUserGuid"] = new SelectList(_context.TbCompanyUsers, "compUserGuid", "FirstName", tbBeneficialies.compUserGuid);
            return View(tbBeneficialies);
        }

        // GET: Beneficialies/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbBeneficialies = await _context.TbBeneficialies
               // .Include(t => t.tbIndivuduals)
                .SingleOrDefaultAsync(m => m.benGuid == id);
            if (tbBeneficialies == null)
            {
                return NotFound();
            }

            return View(tbBeneficialies);
        }

        // POST: Beneficialies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tbBeneficialies = await _context.TbBeneficialies.SingleOrDefaultAsync(m => m.benGuid == id);
            _context.TbBeneficialies.Remove(tbBeneficialies);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbBeneficialiesExists(Guid id)
        {
            return _context.TbBeneficialies.Any(e => e.benGuid == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;

namespace Spa_Management.Controllers
{
    public class SpaRolesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private static IHostingEnvironment _env;
        public SpaRolesController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IDbOperations operations, IHostingEnvironment hosting)
        {
            _context = context;
            _userManager = userManager;
            _dbOps = operations;
            _env = hosting;
        }
       

        // GET: SpaRoles
        public async Task<IActionResult> Index()
        {
            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var spaUserGuid = me.spaUserGuid;
                var spaId = _context.SpaUsers.AsNoTracking().FirstOrDefault(c => c.spaUserGuid == spaUserGuid).spaGuid;
                var applicationDbContext_ = _context.SpaRoles.Where(c => c.SpaDetailsId == spaId).Include(s => s.SpaDetails);
                return View(await applicationDbContext_.ToListAsync());
            }
            catch (Exception ex )
            {

                throw ex;
            }
        }

        // GET: SpaRoles/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaRoles = await _context.SpaRoles
                .Include(s => s.SpaDetails)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spaRoles == null)
            {
                return NotFound();
            }

            return View(spaRoles);
        }

        // GET: SpaRoles/Create
        public IActionResult Create()
        {
            ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo");
            return View();
        }

        // POST: SpaRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SpaDetailsId,Status,RoleName")] SpaRoles spaRoles)
        {

            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var spaUserGuid = me.spaUserGuid;
                var spaId = _context.SpaUsers.AsNoTracking().FirstOrDefault(c => c.spaUserGuid == spaUserGuid).spaGuid;
                spaRoles.Id = Guid.NewGuid();
                spaRoles.SpaDetailsId = spaId;
                _context.Add(spaRoles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {

                await _dbOps.LogError("SpaRoles/Create", "Add new User Role", "", ex.Message.ToString(), object.ReferenceEquals(ex.InnerException, null) ? "" : ex.InnerException.ToString());
            }
        ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "SpaName", spaRoles.SpaDetailsId);
         return View(spaRoles);
            //if (ModelState.IsValid)
            //{
            //    spaRoles.Id = Guid.NewGuid();
            //    _context.Add(spaRoles);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}

        }

        // GET: SpaRoles/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaRoles = await _context.SpaRoles.SingleOrDefaultAsync(m => m.Id == id);
            if (spaRoles == null)
            {
                return NotFound();
            }
            ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "SpaName", spaRoles.SpaDetailsId);
            return View(spaRoles);
        }

        // POST: SpaRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,SpaDetailsId,Status,RoleName")] SpaRoles spaRoles)
        {
            if (id != spaRoles.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var me = await _userManager.GetUserAsync(HttpContext.User);
                    var spaUserGuid = me.spaUserGuid;
                    var spaId = _context.SpaUsers.AsNoTracking().FirstOrDefault(c => c.spaUserGuid == spaUserGuid).spaGuid;
                    spaRoles.SpaDetailsId = spaId;
                    _context.Update(spaRoles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaRolesExists(spaRoles.Id))
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
            ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo", spaRoles.SpaDetailsId);
            return View(spaRoles);
        }

        // GET: SpaRoles/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaRoles = await _context.SpaRoles
                .Include(s => s.SpaDetails)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spaRoles == null)
            {
                return NotFound();
            }

            return View(spaRoles);
        }

        // POST: SpaRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spaRoles = await _context.SpaRoles.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpaRoles.Remove(spaRoles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaRolesExists(Guid id)
        {
            return _context.SpaRoles.Any(e => e.Id == id);
        }
    }
}

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
using Spa_Management.Interfaces;

namespace Spa_Management.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;

        public NotificationsController(ApplicationDbContext context, IDbOperations dbOps, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = userManager;
        }

        // GET: Notifications
        public async Task<IActionResult> Index()
        {
            
            if (User.IsInRole("MasterAdmin"))
            {
                return View(await _context.TbNotifications.ToListAsync());
            }
            else
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                return View(await _context.TbNotifications.Where(i=>i.systemID == me.Id).OrderByDescending(c=>c.logDate).ToListAsync());
            }
            //return View(await _context.TbNotifications.ToListAsync());
        }

        // GET: Notifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbNotifications = await _context.TbNotifications
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbNotifications == null)
            {
                return NotFound();
            }
            tbNotifications.status = 1;
            _context.Update(tbNotifications);
            await _context.SaveChangesAsync();
           return RedirectToAction(nameof(Index));
        }

        //// GET: Notifications/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Notifications/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,systemID,type,message,logDate,status")] tbNotifications tbNotifications)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(tbNotifications);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tbNotifications);
        //}

        //// GET: Notifications/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tbNotifications = await _context.TbNotifications.SingleOrDefaultAsync(m => m.Id == id);
        //    if (tbNotifications == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tbNotifications);
        //}

        //// POST: Notifications/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Id,systemID,type,message,logDate,status")] tbNotifications tbNotifications)
        //{
        //    if (id != tbNotifications.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tbNotifications);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!tbNotificationsExists(tbNotifications.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tbNotifications);
        //}

        //// GET: Notifications/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var tbNotifications = await _context.TbNotifications
        //        .SingleOrDefaultAsync(m => m.Id == id);
        //    if (tbNotifications == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tbNotifications);
        //}

        //// POST: Notifications/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var tbNotifications = await _context.TbNotifications.SingleOrDefaultAsync(m => m.Id == id);
        //    _context.TbNotifications.Remove(tbNotifications);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool tbNotificationsExists(int id)
        {
            return _context.TbNotifications.Any(e => e.Id == id);
        }
    }
}

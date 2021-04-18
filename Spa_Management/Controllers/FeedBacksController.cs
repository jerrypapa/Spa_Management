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

namespace Spa_Management.Controllers
{
    public class FeedBacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;
        public readonly SignInManager<ApplicationUser> _SignInManager;
        public FeedBacksController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FeedBacks
        public async Task<IActionResult> Index()
        {
            if (User.IsInRole("MasterAdmin"))
            {
                return View(await _context.TbFeedBacks.ToListAsync());
            }
            else
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                return View(await _context.TbFeedBacks.Where(i => i.email == me.Email).OrderByDescending(c => c.time).ToListAsync());
            }
         
        }

        // GET: FeedBacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFeedBacks = await _context.TbFeedBacks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbFeedBacks == null)
            {
                return NotFound();
            }

            return View(tbFeedBacks);
        }

        // GET: FeedBacks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FeedBacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,email,phone,message")] tbFeedBacks tbFeedBacks)
        {
            if (ModelState.IsValid)
            {
                 tbFeedBacks.time = DateTime.Now;
                tbFeedBacks.status = 0;
                _context.Add(tbFeedBacks);
                await _context.SaveChangesAsync();

                //if (_SignInManager.IsSignedIn(User))
                //{
                //    return RedirectToAction(nameof(Index));
                //}
                //else
                //{
                //    return RedirectToAction(nameof(Create));
                //}
                ViewBag.Message = "Sent";
                return Content("Sent");

            }
            return View(tbFeedBacks);
        }

        // GET: FeedBacks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFeedBacks = await _context.TbFeedBacks.SingleOrDefaultAsync(m => m.Id == id);
            if (tbFeedBacks == null)
            {
                return NotFound();
            }
            return View(tbFeedBacks);
        }

        // POST: FeedBacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,name,email,phone,message,time,status")] tbFeedBacks tbFeedBacks)
        {
            if (id != tbFeedBacks.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbFeedBacks);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!tbFeedBacksExists(tbFeedBacks.Id))
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
            return View(tbFeedBacks);
        }

        // GET: FeedBacks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tbFeedBacks = await _context.TbFeedBacks
                .SingleOrDefaultAsync(m => m.Id == id);
            if (tbFeedBacks == null)
            {
                return NotFound();
            }

            return View(tbFeedBacks);
        }

        // POST: FeedBacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tbFeedBacks = await _context.TbFeedBacks.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbFeedBacks.Remove(tbFeedBacks);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool tbFeedBacksExists(int id)
        {
            return _context.TbFeedBacks.Any(e => e.Id == id);
        }
    }
}

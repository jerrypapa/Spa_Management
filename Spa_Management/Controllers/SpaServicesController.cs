using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Interfaces.Spa;
using Spa_Management.Models;

namespace Spa_Management.Controllers
{
    public class SpaServicesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly ISpaOperations _spaOperations;
        private readonly UserManager<ApplicationUser> _userManager;
        public SpaServicesController(ApplicationDbContext context, IDbOperations dbOps, ISpaOperations spaOperations, UserManager<ApplicationUser> manager)
        {
            _dbOps = dbOps;
            _context = context;
            _userManager = manager;
            _spaOperations = spaOperations;
        }

        // GET: SpaServices
        public async Task<IActionResult> Index()
        {

            if (User.IsInRole("Spa Admin"))
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var spaid = _context.SpaUsers.AsNoTracking().FirstOrDefault(j => j.spaUserGuid == me.spaUserGuid).spaGuid;
                var applicationDbContext = _context.SpaServices_.AsNoTracking().Where(c => c.SpaDetailsId == spaid).Include(s => s.SpaDetails);
                List<ViewspaServices> spaServices = new List<ViewspaServices>();
                int i = 1;
                foreach (var a in applicationDbContext)
                {
                    ViewspaServices user = new ViewspaServices()
                    {
                        id = i++,
                        Code = a.Code,
                        ServiceName = a.ServiceName,
                        Price = a.Price,
                        status = 1,
                        Id=a.Id

                    };
                    spaServices.Add(user);
                }
                ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == spaid).spaName;
                ViewData["spaGuid"] = spaid;
                return View(spaServices);
            }
            return new ForbidResult();
        }

        // GET: SpaServices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaServices = await _context.SpaServices_
                .Include(s => s.SpaDetails)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spaServices == null)
            {
                return NotFound();
            }

            return View(spaServices);
        }

        // GET: SpaServices/Create
        public async Task<IActionResult> Create(Guid? id)
        {
            Guid spaid = Guid.Empty;

            if (id == null)
            {
                return NotFound();
            }
            if (User.IsInRole("Spa Admin"))
            {
                var me2 = await _userManager.GetUserAsync(HttpContext.User);
                spaid = _context.SpaUsers.AsNoTracking().FirstOrDefault(j => j.spaUserGuid == me2.spaUserGuid).spaGuid;
            }
            var user = new SpaUsers() { spaGuid = id.Value };
            ViewData["spaName"] = _context.SpaDetails.FirstOrDefault(k => k.spaGuid == id).spaName;
            ViewData["spaGuid"] = spaid;
            return View(user);
            
        }
        //public IActionResult Create()
        //{
        //    ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo");
        //    return View();
        //}

        // POST: SpaServices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceName,Code,Price,SpaDetailsId")] SpaServices spaServices)
        {
            Guid spaid = Guid.Empty;
            if (ModelState.IsValid)
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                spaid = _context.SpaUsers.AsNoTracking().FirstOrDefault(j => j.spaUserGuid == me.spaUserGuid).spaGuid;

                spaServices.SpaDetailsId = spaid;
                spaServices.Id = Guid.NewGuid();
                _context.Add(spaServices);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails.Where(c=>c.spaGuid== spaid), "spaGuid", "SpaName", spaServices.SpaDetailsId);
            return View(spaServices);
        }

        // GET: SpaServices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaServices = await _context.SpaServices_.SingleOrDefaultAsync(m => m.Id == id);
            if (spaServices == null)
            {
                return NotFound();
            }
            ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo", spaServices.SpaDetailsId);
            return View(spaServices);
        }

        // POST: SpaServices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ServiceName,Code,Price,SpaDetailsId")] SpaServices spaServices)
        {
            if (id != spaServices.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spaServices);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpaServicesExists(spaServices.Id))
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
            ViewData["SpaDetailsId"] = new SelectList(_context.SpaDetails, "spaGuid", "PinNo", spaServices.SpaDetailsId);
            return View(spaServices);
        }

        // GET: SpaServices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spaServices = await _context.SpaServices_
                .Include(s => s.SpaDetails)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (spaServices == null)
            {
                return NotFound();
            }

            return View(spaServices);
        }

        // POST: SpaServices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var spaServices = await _context.SpaServices_.SingleOrDefaultAsync(m => m.Id == id);
            _context.SpaServices_.Remove(spaServices);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpaServicesExists(Guid id)
        {
            return _context.SpaServices_.Any(e => e.Id == id);
        }


        public class ViewspaServices
        {
            public int id { get; set; }
           
            [Display(Name = "Service Code")]
            public string Code { get; set; }

            [Display(Name = "Service Name")]
            public string ServiceName { get; set; }

            [Display(Name = "Price")]
            public decimal Price { get; set; }

            public int status { get; set; }
            public Guid Id { get; set; }
        }
    }
}

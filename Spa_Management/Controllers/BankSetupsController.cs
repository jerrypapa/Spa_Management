using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using System.IO;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Spa_Management.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace Spa_Management.Controllers
{
    public class BankSetupsController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private static IHostingEnvironment _env;
        public BankSetupsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager, IDbOperations operations, IHostingEnvironment hosting)
        {
            _context = context;
            _userManager = userManager;
            _dbOps = operations;
            _env = hosting;
        }

        // GET: BankSetups
        public async Task<IActionResult> Index()
        {
            return View(await _context.TbBankSetups.ToListAsync());
        }

        // GET: BankSetups/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankSetups = await _context.TbBankSetups
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bankSetups == null)
            {
                return NotFound();
            }

            return View(bankSetups);
        }

        // GET: BankSetups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BankSetups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BankId,letterHead,Signature,Logo,Stamp,Status")] BankSetups bankSetups)
        {
            if (ModelState.IsValid)
            {
                bankSetups.Id = Guid.NewGuid();
                _context.Add(bankSetups);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bankSetups);
        }

        // GET: BankSetups/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankSetups = await _context.TbBankSetups.SingleOrDefaultAsync(m => m.Id == id);
            if (bankSetups == null)
            {
                return NotFound();
            }
            return View(bankSetups);
        }

        // POST: BankSetups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBankParams([Bind("Id,BankId,letterHead,Signature,Logo,Stamp,Status")] BankSetups bankSetups, IFormFile letterHead, IFormFile Signature, IFormFile Logo, IFormFile Stamp)
        {
            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var bankId_ = me.bankUserGuid;
                var bankId = _context.TbBankUsers.FirstOrDefault(c => c.SystemBanksGuid == bankId_).SystemBanksGuid;
                // var bankId=_context.TbBankUsers.FirstOrDefault(b=>b.ban)

                if ((letterHead != null && letterHead.Length > 0 && !string.IsNullOrEmpty(letterHead.FileName)) && ((Signature != null && Signature.Length > 0 && !string.IsNullOrEmpty(Signature.FileName)) && ((Logo != null && Logo.Length > 0 && !string.IsNullOrEmpty(Logo.FileName)) && ((Stamp != null && Stamp.Length > 0 && !string.IsNullOrEmpty(Stamp.FileName))))))
                {
                    var fileName1 = Path.GetFileName(letterHead.FileName);
                    var logoFileName = Path.GetFileName(Logo.FileName);
                    var StampFileName = Path.GetFileName(Stamp.FileName);
                    var SignatureFileName = Path.GetFileName(Signature.FileName);


                    //letterhead

                    if (Path.GetExtension(fileName1) == ".jpg" || Path.GetExtension(fileName1) == ".jpeg" || Path.GetExtension(fileName1) == ".png")
                    {
                        fileName1 = "lh" + bankId + fileName1;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", fileName1);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await letterHead.CopyToAsync(strea);
                        }

                        var letterhead = bankSetups.letterHead = "BankFiles/" + fileName1;
                    }

                    //logo
                    if (Path.GetExtension(logoFileName) == ".jpg" || Path.GetExtension(logoFileName) == ".jpeg" || Path.GetExtension(logoFileName) == ".png")
                    {
                        logoFileName = "log" + bankId + logoFileName;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", logoFileName);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await Logo.CopyToAsync(strea);
                        }

                        var bankLogo = bankSetups.Logo = "BankFiles/" + logoFileName;
                    }

                    //signature

                    if (Path.GetExtension(SignatureFileName) == ".jpg" || Path.GetExtension(SignatureFileName) == ".jpeg" || Path.GetExtension(SignatureFileName) == ".png")
                    {
                        SignatureFileName = "sig" + bankId + SignatureFileName;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", SignatureFileName);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await Signature.CopyToAsync(strea);
                        }

                        var bankSignature = bankSetups.Signature = "BankFiles/" + SignatureFileName;
                    }

                    //stamp

                    if (Path.GetExtension(StampFileName) == ".jpg" || Path.GetExtension(StampFileName) == ".jpeg" || Path.GetExtension(StampFileName) == ".png")
                    {
                        StampFileName = "stmp" + bankId + StampFileName;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", StampFileName);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await Stamp.CopyToAsync(strea);
                        }

                        var bankStamp = bankSetups.Stamp = "BankFiles/" + fileName1;
                    }
                }

                bankSetups.Id = Guid.NewGuid();
                bankSetups.Status = 0;
                bankSetups.BankId = bankId;
                _context.Add(bankSetups);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,BankId,letterHead,Signature,Logo,Stamp,Status")] BankSetups bankSetups, IFormFile letterHead, IFormFile Signature, IFormFile Logo, IFormFile Stamp)
        {
            if (id != bankSetups.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var me = await _userManager.GetUserAsync(HttpContext.User);
                    var bankId_ = me.bankUserGuid;
                    var bankId = _context.TbBankUsers.FirstOrDefault(c => c.SystemBanksGuid == bankId_).SystemBanksGuid;
                    if ((letterHead != null && letterHead.Length > 0 && !string.IsNullOrEmpty(letterHead.FileName)) && ((Signature != null && Signature.Length > 0 && !string.IsNullOrEmpty(Signature.FileName)) && ((Logo != null && Logo.Length > 0 && !string.IsNullOrEmpty(Logo.FileName)) && ((Stamp != null && Stamp.Length > 0 && !string.IsNullOrEmpty(Stamp.FileName))))))
                    {
                        var fileName1 = Path.GetFileName(letterHead.FileName);
                        var logoFileName = Path.GetFileName(Logo.FileName);
                        var StampFileName = Path.GetFileName(Stamp.FileName);
                        var SignatureFileName = Path.GetFileName(Signature.FileName);


                        //letterhead

                        if (Path.GetExtension(fileName1) == ".jpg" || Path.GetExtension(fileName1) == ".jpeg" || Path.GetExtension(fileName1) == ".png")
                        {
                            fileName1 = "lh" + bankId + fileName1;
                            //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                            var uploads = Path.Combine(_env.WebRootPath, "BankFiles", fileName1);
                            //var myfilePath = Path.Combine(uploads, fileName);
                            using (var strea = new FileStream(uploads, FileMode.Create))
                            {
                                await letterHead.CopyToAsync(strea);
                            }

                            var letterhead = bankSetups.letterHead = "BankFiles/" + fileName1;
                        }

                        //logo
                        if (Path.GetExtension(logoFileName) == ".jpg" || Path.GetExtension(logoFileName) == ".jpeg" || Path.GetExtension(logoFileName) == ".png")
                        {
                            logoFileName = "log" + bankId + logoFileName;
                            //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                            var uploads = Path.Combine(_env.WebRootPath, "BankFiles", logoFileName);
                            //var myfilePath = Path.Combine(uploads, fileName);
                            using (var strea = new FileStream(uploads, FileMode.Create))
                            {
                                await Logo.CopyToAsync(strea);
                            }

                            var bankLogo = bankSetups.Logo = "BankFiles/" + logoFileName;
                        }

                        //signature

                        if (Path.GetExtension(SignatureFileName) == ".jpg" || Path.GetExtension(SignatureFileName) == ".jpeg" || Path.GetExtension(SignatureFileName) == ".png")
                        {
                            SignatureFileName = "sig" + bankId + SignatureFileName;
                            //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                            var uploads = Path.Combine(_env.WebRootPath, "BankFiles", SignatureFileName);
                            //var myfilePath = Path.Combine(uploads, fileName);
                            using (var strea = new FileStream(uploads, FileMode.Create))
                            {
                                await Signature.CopyToAsync(strea);
                            }

                            var bankSignature = bankSetups.Signature = "BankFiles/" + SignatureFileName;
                        }

                        //stamp

                        if (Path.GetExtension(StampFileName) == ".jpg" || Path.GetExtension(StampFileName) == ".jpeg" || Path.GetExtension(StampFileName) == ".png")
                        {
                            StampFileName = "stmp" + bankId + StampFileName;
                            //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                            var uploads = Path.Combine(_env.WebRootPath, "BankFiles", StampFileName);
                            //var myfilePath = Path.Combine(uploads, fileName);
                            using (var strea = new FileStream(uploads, FileMode.Create))
                            {
                                await Stamp.CopyToAsync(strea);
                            }

                            var bankStamp = bankSetups.Stamp = "BankFiles/" + fileName1;
                        }
                    }

                    //
                    bankSetups.Status = 0;
                    bankSetups.BankId = bankId;
                    _context.Update(bankSetups);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BankSetupsExists(bankSetups.Id))
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
            return View(bankSetups);
        }

        // GET: BankSetups/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bankSetups = await _context.TbBankSetups
                .SingleOrDefaultAsync(m => m.Id == id);
            if (bankSetups == null)
            {
                return NotFound();
            }

            return View(bankSetups);
        }
        public async Task<IActionResult> Download(string filename)
        {
            if (filename == null)
                return Content("filename not present");

            var path = Path.Combine(
                           Directory.GetCurrentDirectory(),
                           "wwwroot/", filename);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }
        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformatsofficedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
        // POST: BankSetups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var bankSetups = await _context.TbBankSetups.SingleOrDefaultAsync(m => m.Id == id);
            _context.TbBankSetups.Remove(bankSetups);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BankSetupsExists(Guid id)
        {
            return _context.TbBankSetups.Any(e => e.Id == id);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetupBankParams([Bind("Id,BankId,letterHead,Signature,Logo,Stamp,Status")] BankSetups bankSetups, IFormFile letterHead, IFormFile Signature, IFormFile Logo, IFormFile Stamp)
        {
            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var bankId_ = me.bankUserGuid;
                var bankId = _context.TbBankUsers.FirstOrDefault(c => c.SystemBanksGuid == bankId_).SystemBanksGuid;
                // var bankId=_context.TbBankUsers.FirstOrDefault(b=>b.ban)

                if ((letterHead != null && letterHead.Length > 0 && !string.IsNullOrEmpty(letterHead.FileName)) && ((Signature != null && Signature.Length > 0 && !string.IsNullOrEmpty(Signature.FileName)) && ((Logo != null && Logo.Length > 0 && !string.IsNullOrEmpty(Logo.FileName)) && ((Stamp != null && Stamp.Length > 0 && !string.IsNullOrEmpty(Stamp.FileName))))))
                {
                    var fileName1 = Path.GetFileName(letterHead.FileName);
                    var logoFileName = Path.GetFileName(Logo.FileName);
                    var StampFileName = Path.GetFileName(Stamp.FileName);
                    var SignatureFileName = Path.GetFileName(Signature.FileName);


                    //letterhead

                    if (Path.GetExtension(fileName1) == ".jpg" || Path.GetExtension(fileName1) == ".jpeg" || Path.GetExtension(fileName1) == ".png")
                    {
                        fileName1 = "lh" + bankId + fileName1;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", fileName1);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await letterHead.CopyToAsync(strea);
                        }

                        var letterhead = bankSetups.letterHead = "BankFiles/" + fileName1;
                    }

                    //logo
                    if (Path.GetExtension(logoFileName) == ".jpg" || Path.GetExtension(logoFileName) == ".jpeg" || Path.GetExtension(logoFileName) == ".png")
                    {
                        logoFileName = "log" + bankId + logoFileName;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", logoFileName);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await Logo.CopyToAsync(strea);
                        }

                        var bankLogo = bankSetups.Logo = "BankFiles/" + logoFileName;
                    }

                    //signature

                    if (Path.GetExtension(SignatureFileName) == ".jpg" || Path.GetExtension(SignatureFileName) == ".jpeg" || Path.GetExtension(SignatureFileName) == ".png")
                    {
                        SignatureFileName = "sig" + bankId + SignatureFileName;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", SignatureFileName);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await Signature.CopyToAsync(strea);
                        }

                        var bankSignature = bankSetups.Signature = "BankFiles/" + SignatureFileName;
                    }

                    //stamp

                    if (Path.GetExtension(StampFileName) == ".jpg" || Path.GetExtension(StampFileName) == ".jpeg" || Path.GetExtension(StampFileName) == ".png")
                    {
                        StampFileName = "stmp" + bankId + StampFileName;
                        //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                        var uploads = Path.Combine(_env.WebRootPath, "BankFiles", StampFileName);
                        //var myfilePath = Path.Combine(uploads, fileName);
                        using (var strea = new FileStream(uploads, FileMode.Create))
                        {
                            await Stamp.CopyToAsync(strea);
                        }

                        var bankStamp = bankSetups.Stamp = "BankFiles/" + fileName1;
                    }
                }

                bankSetups.Id = Guid.NewGuid();
                bankSetups.Status = 0;
                bankSetups.BankId = bankId;
                _context.Add(bankSetups);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }

        public class SetupsView
        {
            public Guid Id { get; set; }
            public Guid BankId { get; set; }
            [Required]
            [Display(Name = "LetterHead")]
            [MaxLength(800)]
            public string letterHead { get; set; }

            [Required]
            [Display(Name = "Signature")]
            [MaxLength(800)]
            public string Signature { get; set; }

            [Required]
            [Display(Name = "Logo")]
            [MaxLength(800)]
            public string Logo { get; set; }

            [Required]
            [Display(Name = "Stamp")]
            [MaxLength(800)]
            public string Stamp { get; set; }
            public int Status { get; set; }

        }
    }
}

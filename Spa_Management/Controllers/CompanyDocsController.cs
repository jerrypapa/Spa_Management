using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Spa_Management.Interfaces;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.Extensions.FileProviders;

namespace Spa_Management.Controllers
{
    public class CompanyDocsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private readonly UserManager<ApplicationUser> _userManager;
        private static IHostingEnvironment _env;
        private readonly IFileProvider _fileProvider;


        public CompanyDocsController(ApplicationDbContext context, IHostingEnvironment hosting,
            IDbOperations dbOps, UserManager<ApplicationUser> manager, IFileProvider fileProvider)
        {
            _context = context;
            _dbOps = dbOps;
            _userManager = manager;
            _env = hosting;
            _fileProvider = fileProvider;
            // _client = client;
            //_emailSender = emailSender;
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
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
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
        // GET: CompanyDocs
        public async Task<IActionResult> Index(int id)
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("CompanyAdmin"))
            {
                var me1 = await _userManager.GetUserAsync(HttpContext.User);
                var companyId = _context.TbCompanyUsers.AsNoTracking().FirstOrDefault(c => c.compUserGuid == me.compUserGuid).compGuid;

                var companyDocs = _context.TbCompanyDocs.AsNoTracking().FirstOrDefault(c => c.CompanyId == companyId);

                if (companyDocs == null)
                {
                    ViewData["DocsUploaded"] = false;

                    ViewData["BoardResolutionDocPath"] = " ";
                    ViewData["RegCertDocPath"] = " ";
                    ViewData["PinCertDocPath"] = " ";
                    ViewData["Cr12DocPath"] = " ";
                    ViewData["State0"] = 20;
                    ViewData["DocsId"] = Guid.Empty;
                }
                else
                {
                    ViewData["DocsUploaded"] = true;
                    ViewData["BoardResolutionDocPath"] = companyDocs.BoardResolution;
                    ViewData["RegCertDocPath"] = companyDocs.RegistrationCertificate;
                    ViewData["PinCertDocPath"] = companyDocs.PinCertificate;
                    ViewData["Cr12DocPath"] = companyDocs.Cr12;
                    ViewData["State0"] = companyDocs.Status;
                    ViewData["DocsId"] = companyDocs.Id;
                }
                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var userId = me.compUserGuid;
                    var companyId1 = _context.TbCompanyUsers.AsNoTracking().FirstOrDefault(c => c.compUserGuid == userId).compGuid;

                    // var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;  There is an error here

                    //Optimize querries afterwards
                    var CompanyDirectors = _context.TbDirectors.AsNoTracking().Where(c => c.CompanyId == companyId1 && c.OtpVerified == true).ToList();
                    var companyDocuments = _context.TbCompanyDocs.AsNoTracking().FirstOrDefault(c => c.CompanyId == companyId1);
                    if (CompanyDirectors.Count() <= 0)
                    {

                        //Flag with correct details
                        ViewData["DirectorsRegistered"] = false; //should be false after test
                        ViewData["DocumentsVerified"] = false;
                        ViewData["DirectorsVerified"] = false;
                        ViewData["DocumentsRegistered"] = false;


                        //Redirect To Registration Page for Directors
                    }
                    else
                    {

                        if (companyDocuments == null)
                        {
                            var AtleastOnedirectorVerified1 = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            if (AtleastOnedirectorVerified1 > 0)
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = true;
                            }
                            else
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = false;
                            }
                            ViewData["DocumentsVerified"] = false;

                            ViewData["DocumentsRegistered"] = false;
                        }
                        else
                        {


                            var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            var DocsApproved = companyDocuments.Verified;

                            if (AtleastOnedirectorVerified > 0 && DocsApproved == true)
                            {
                                ViewData["DocumentsVerified"] = true;
                                ViewData["DirectorsVerified"] = true;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = DocsApproved;
                            }
                            else
                            {
                                bool dirAppr = true;
                                if (AtleastOnedirectorVerified <= 0)
                                {
                                    dirAppr = false;
                                }

                                ViewData["DocumentsVerified"] = DocsApproved;
                                ViewData["DirectorsVerified"] = dirAppr;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = true;
                            }

                        }

                    }
                }

            }
            

           

            List<CompanyDocs> ApplicationDbContext = null;
            if (User.IsInRole("MasterAdmin"))
            {
                ApplicationDbContext = id == 0 ? await _context.TbCompanyDocs.ToListAsync() : await _context.TbCompanyDocs.Where(c => c.Status == 0).ToListAsync();
                ViewData["State0"] = 0;
            }
            else
            {
                var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == me.compUserGuid).compGuid;
                ApplicationDbContext = await _context.TbCompanyDocs.Where(c => c.CompanyId == companyId).ToListAsync();
            }
          //  var ApplicationDbContext = id == 0 ? _context.TbCompanyDocs.Where(c => c.CompanyId == companyId).ToListAsync() : _context.TbDirectors.Where(k => k.OtpVerified == true && k.Verified == false);
            return View(ApplicationDbContext);
        }
        public async Task<IActionResult> ApproveDocs(string Details,string btn, string appId)
        {
            if (appId == null)
            {
                return NotFound();
            }
            Guid gui = Guid.Parse(appId);
            var tbCompanyDocs = await _context.TbCompanyDocs
                .FirstOrDefaultAsync(m => m.Id == gui);

           var appicantId= tbCompanyDocs.ApplicantId;

            var applicantDetails =  _context.TbCompanyUsers.AsNoTracking().FirstOrDefaultAsync(c => c.compUserGuid == appicantId);


            if (tbCompanyDocs == null)
            {
                return NotFound();
            }

                    if (btn == "Approve")
                    {
                        if (tbCompanyDocs.Status == 0)
                        {
                            tbCompanyDocs.Status = 1;
                            tbCompanyDocs.AdminComments = Details;

                    //log info to users
                    //send them mails and sms
                           // await _dbOps.LogNotification(applicantDetails.Id, 1, "Your Application has been Approved step 1");
                        }
                        else
                        {
                        }

                    }
                    if (btn == "Reject")
                    {
                        if (tbCompanyDocs.Status == 0)
                        {
                             tbCompanyDocs.Status = 2;
                             tbCompanyDocs.AdminComments = Details;
                  //     await _dbOps.LogNotification(profile.Id, 1, "Your Application has been Rejected step 1");
                            //_dbOps.logandSendSMS(profile.PhoneNumber, "Your Application has been Rejected step 1");
                        }
                        else
                        {
                            
                          
                        }
                    }
            _context.Update(tbCompanyDocs);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        // GET: CompanyDocs/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var companyDocs = await _context.TbCompanyDocs
                .SingleOrDefaultAsync(m => m.CompanyId == id);
            if (companyDocs == null)
            {
                return NotFound();
            }
            ViewData["BoardResolutionDocPath"] = companyDocs.BoardResolution;
            ViewData["RegCertDocPath"] = companyDocs.RegistrationCertificate;
            ViewData["PinCertDocPath"] = companyDocs.PinCertificate;
            ViewData["Cr12DocPath"] = companyDocs.Cr12;
            ViewData["Gui"] = id;
            ViewData["State0"] = companyDocs.Status;
            ViewData["DocsId"] = companyDocs.Id;

            return View(companyDocs);
        }

        // GET: CompanyDocs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CompanyDocs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyId,Status,BoardResolution,PinCertificate,RegistrationCertificate,Cr12")] CompanyDocs companyDocs)
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            if (User.IsInRole("CompanyAdmin"))
            {
                if (User.IsInRole("CompanyUser") || User.IsInRole("CompanyAdmin"))
                {
                    var userId = me.compUserGuid;
                    var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;

                    // var companyId = _context.TbCompanyUsers.FirstOrDefault(c => c.compUserGuid == userId).compGuid;  There is an error here

                    //Optimize querries afterwards
                    var CompanyDirectors = _context.TbDirectors.Where(c => c.CompanyId == companyId && c.OtpVerified == true).ToList();
                    var companyDocuments = _context.TbCompanyDocs.FirstOrDefault(c => c.CompanyId == companyId);
                    if (CompanyDirectors.Count() <= 0)
                    {

                        //Flag with correct details
                        ViewData["DirectorsRegistered"] = false; //should be false after test
                        ViewData["DocumentsVerified"] = false;
                        ViewData["DirectorsVerified"] = false;
                        ViewData["DocumentsRegistered"] = false;


                        //Redirect To Registration Page for Directors
                    }
                    else
                    {

                        if (companyDocuments == null)
                        {
                            var AtleastOnedirectorVerified1 = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            if (AtleastOnedirectorVerified1 > 0)
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = true;
                            }
                            else
                            {
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DirectorsVerified"] = false;
                            }
                            ViewData["DocumentsVerified"] = false;

                            ViewData["DocumentsRegistered"] = false;
                        }
                        else
                        {


                            var AtleastOnedirectorVerified = CompanyDirectors.Count(d => d.Verified == true && d.OtpVerified == true);
                            var DocsApproved = companyDocuments.Verified;

                            if (AtleastOnedirectorVerified > 0 && DocsApproved == true)
                            {
                                ViewData["DocumentsVerified"] = true;
                                ViewData["DirectorsVerified"] = true;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = DocsApproved;
                            }
                            else
                            {
                                bool dirAppr = true;
                                if (AtleastOnedirectorVerified <= 0)
                                {
                                    dirAppr = false;
                                }

                                ViewData["DocumentsVerified"] = DocsApproved;
                                ViewData["DirectorsVerified"] = dirAppr;
                                ViewData["DirectorsRegistered"] = true;
                                ViewData["DocumentsRegistered"] = true;
                            }

                        }

                    }
                }
            }
            if (ModelState.IsValid)
            {
                //Check if Documents already Uploaded

                companyDocs.Id = Guid.NewGuid();
                _context.Add(companyDocs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(companyDocs);
        }
        //SetupCompanyDocs
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetupCompanyDocs([Bind("Id,CompanyId,Status,BoardResolution,PinCertificate,RegistrationCertificate,Cr12")] CompanyDocs companyDocs, IFormFile BoardResolution, IFormFile PinCertificate, IFormFile RegistrationCertificate, IFormFile Cr12)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    var me = await _userManager.GetUserAsync(HttpContext.User);
                    var companyId_ = me.compUserGuid;
                    var companyId = _context.TbCompanyUsers.AsNoTracking().FirstOrDefault(c => c.compUserGuid == companyId_).compGuid;
                    // var companyId=_context.TbBankUsers.FirstOrDefault(b=>b.ban)
                    try
                    {
                        if (BoardResolution == null)
                        {
                            ModelState.AddModelError("", "Please Attach Board Resolution Pdf Document");
                        }
                        if (PinCertificate == null)
                        {
                            ModelState.AddModelError("", "Please Attach Pin Certificate Pdf Document");
                        }
                        if (RegistrationCertificate == null)
                        {
                            ModelState.AddModelError("", "Please Attach Registration Certificate Pdf Document");
                        }
                        if (Cr12 == null)
                        {
                            ModelState.AddModelError("", "Please Attach CR12 Pdf Document");
                        }

                        if ((BoardResolution != null && BoardResolution.Length > 0 && !string.IsNullOrEmpty(BoardResolution.FileName)) && ((PinCertificate != null && PinCertificate.Length > 0 && !string.IsNullOrEmpty(PinCertificate.FileName)) && ((RegistrationCertificate != null && RegistrationCertificate.Length > 0 && !string.IsNullOrEmpty(RegistrationCertificate.FileName)) && ((Cr12 != null && Cr12.Length > 0 && !string.IsNullOrEmpty(Cr12.FileName))))))
                        {
                            var fileName1 = Path.GetFileName(BoardResolution.FileName);
                            var RegistrationCertificateFileName = Path.GetFileName(RegistrationCertificate.FileName);
                            var Cr12FileName = Path.GetFileName(Cr12.FileName);
                            var PinCertificateFileName = Path.GetFileName(PinCertificate.FileName);


                            //BoardResolution

                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(fileName1) == ".jpg" || Path.GetExtension(fileName1) == ".jpeg" || Path.GetExtension(fileName1) == ".png")
                            {
                                fileName1 = "Rsl" + companyId + fileName1;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", fileName1);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await BoardResolution.CopyToAsync(strea);
                                }

                                var CompanyBoardResolution = companyDocs.BoardResolution = "CompanyFiles/" + fileName1;
                            }

                            //RegistrationCertificate
                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(RegistrationCertificateFileName) == ".jpg" || Path.GetExtension(RegistrationCertificateFileName) == ".jpeg" || Path.GetExtension(RegistrationCertificateFileName) == ".png")
                            {
                                RegistrationCertificateFileName = "RegCert" + companyId + RegistrationCertificateFileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", RegistrationCertificateFileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await RegistrationCertificate.CopyToAsync(strea);
                                }

                                var CompanyRegistrationCertificate = companyDocs.RegistrationCertificate = "CompanyFiles/" + RegistrationCertificateFileName;
                            }

                            //PinCertificate

                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(PinCertificateFileName) == ".jpg" || Path.GetExtension(PinCertificateFileName) == ".jpeg" || Path.GetExtension(PinCertificateFileName) == ".png")
                            {
                                PinCertificateFileName = "PinCert" + companyId + PinCertificateFileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", PinCertificateFileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await PinCertificate.CopyToAsync(strea);
                                }

                                var CompanyPinCertificate = companyDocs.PinCertificate = "CompanyFiles/" + PinCertificateFileName;
                            }

                            //Cr12

                            if (Cr12FileName != null && Cr12FileName.Length > 0 && !string.IsNullOrEmpty(Cr12FileName))
                            {
                                Cr12FileName = "Cr" + companyId + Cr12FileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", Cr12FileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await Cr12.CopyToAsync(strea);
                                }

                                var CompanyCr12 = companyDocs.Cr12 = "CompanyFiles/" + Cr12FileName;
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "Please Attach All Documents in Pdf Format");
                        }
                   // var user = await _context.TbUserProfiles.FirstOrDefaultAsync(g => g.systemID == me.compUserGuid.ToString());

                   // var profile = _context.Users.FirstOrDefault(j => j.Id == user.systemID);

                    companyDocs.Id = Guid.NewGuid();
                        companyDocs.Status = 0;
                        companyDocs.CompanyId = companyId;
                        companyDocs.ApplicantId =Guid.Parse(me.Id);
                        _context.Add(companyDocs);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception e)
                    {

                        await _dbOps.LogError("CompanyDocs", "Create", "", e.Message.ToString(), e.InnerException is null ? "N/A" : e.InnerException.ToString());
                    }
                  
                }
                catch (Exception ex)
                {
                    await _dbOps.LogError("CompanyDocs", "Create", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                   // companyId=
                   // return (RedirectToAction("details", new { id = companyId, f = "Sorry Cannot Verify Details at the moment" }));
                }
            //   }
            //else
            //{
            //    //Load ErrorPage
            //    //Show Error Up There in red
            //}

            //return RedirectToAction(nameof(Index));
            return RedirectToAction(nameof(Index), "mer");
        }

     

        // GET: CompanyDocs/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDocs = await _context.TbCompanyDocs.SingleOrDefaultAsync(m => m.Id == id);
            if (companyDocs == null)
            {
                return NotFound();
            }
            return View(companyDocs);
        }
        public async Task<IActionResult> Ammend(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDocs = await _context.TbCompanyDocs.SingleOrDefaultAsync(m => m.Id == id);
            if (companyDocs == null)
            {
                return NotFound();
            }
            return View(companyDocs);
        }
        // POST: CompanyDocs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Guid id, [Bind("Id,CompanyId,Status,BoardResolution,PinCertificate,RegistrationCertificate,Cr12")] CompanyDocs companyDocs, IFormFile BoardResolution, IFormFile PinCertificate, IFormFile RegistrationCertificate, IFormFile Cr12)
    {
        if (id != companyDocs.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                    using (_context)
                    {

                        var me = await _userManager.GetUserAsync(HttpContext.User);
                        var companyId_ = me.compUserGuid;
                        var companyId = _context.TbCompanyUsers.AsNoTracking().FirstOrDefault(c => c.compUserGuid == companyId_).compGuid;

                        if ((BoardResolution != null && BoardResolution.Length > 0 && !string.IsNullOrEmpty(BoardResolution.FileName)) && ((PinCertificate != null && PinCertificate.Length > 0 && !string.IsNullOrEmpty(PinCertificate.FileName)) && ((RegistrationCertificate != null && RegistrationCertificate.Length > 0 && !string.IsNullOrEmpty(RegistrationCertificate.FileName)) && ((Cr12 != null && Cr12.Length > 0 && !string.IsNullOrEmpty(Cr12.FileName))))))
                        {
                            var fileName1 = Path.GetFileName(BoardResolution.FileName);
                            var RegistrationCertificateFileName = Path.GetFileName(RegistrationCertificate.FileName);
                            var Cr12FileName = Path.GetFileName(Cr12.FileName);
                            var PinCertificateFileName = Path.GetFileName(PinCertificate.FileName);


                            //BoardResolution

                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(fileName1) == ".jpg" || Path.GetExtension(fileName1) == ".jpeg" || Path.GetExtension(fileName1) == ".png")
                            {
                                fileName1 = "Rsl" + companyId + fileName1;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", fileName1);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await BoardResolution.CopyToAsync(strea);
                                }

                                var CompanyBoardResolution = companyDocs.BoardResolution = "CompanyFiles/" + fileName1;
                            }

                            //RegistrationCertificate
                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(RegistrationCertificateFileName) == ".jpg" || Path.GetExtension(RegistrationCertificateFileName) == ".jpeg" || Path.GetExtension(RegistrationCertificateFileName) == ".png")
                            {
                                RegistrationCertificateFileName = "RegCert" + companyId + RegistrationCertificateFileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", RegistrationCertificateFileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await RegistrationCertificate.CopyToAsync(strea);
                                }

                                var CompanyRegistrationCertificate = companyDocs.RegistrationCertificate = "CompanyFiles/" + RegistrationCertificateFileName;
                            }

                            //PinCertificate

                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(PinCertificateFileName) == ".jpg" || Path.GetExtension(PinCertificateFileName) == ".jpeg" || Path.GetExtension(PinCertificateFileName) == ".png")
                            {
                                PinCertificateFileName = "PinCert" + companyId + PinCertificateFileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", PinCertificateFileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await PinCertificate.CopyToAsync(strea);
                                }

                                var CompanyPinCertificate = companyDocs.PinCertificate = "CompanyFiles/" + PinCertificateFileName;
                            }

                            //Cr12

                            if (Cr12FileName != null && Cr12FileName.Length > 0 && !string.IsNullOrEmpty(Cr12FileName))
                            {
                                Cr12FileName = "Cr" + companyId + Cr12FileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", Cr12FileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await Cr12.CopyToAsync(strea);
                                }

                                var CompanyCr12 = companyDocs.Cr12 = "CompanyFiles/" + Cr12FileName;
                            }
                        }

                        companyDocs.Status = 0;
                        companyDocs.CompanyId = companyId;
                        companyDocs.ApplicantId =Guid.Parse(me.Id);
                        _context.Update(companyDocs);
                         _context.SaveChanges();
                    }

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyDocsExists(companyDocs.Id))
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
        return View(companyDocs);
    }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Ammend(Guid id, [Bind("Id,CompanyId,Status,BoardResolution,PinCertificate,RegistrationCertificate,Cr12")] CompanyDocs companyDocs, IFormFile BoardResolution, IFormFile PinCertificate, IFormFile RegistrationCertificate, IFormFile Cr12)
        {
            if (id != companyDocs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    using (_context)
                    {
                        var me = await _userManager.GetUserAsync(HttpContext.User);
                        var companyId_ = me.compUserGuid;
                        var companyId = _context.TbCompanyUsers.AsNoTracking().FirstOrDefault(c => c.compUserGuid == companyId_).compGuid;

                        if ((BoardResolution != null && BoardResolution.Length > 0 && !string.IsNullOrEmpty(BoardResolution.FileName)) && ((PinCertificate != null && PinCertificate.Length > 0 && !string.IsNullOrEmpty(PinCertificate.FileName)) && ((RegistrationCertificate != null && RegistrationCertificate.Length > 0 && !string.IsNullOrEmpty(RegistrationCertificate.FileName)) && ((Cr12 != null && Cr12.Length > 0 && !string.IsNullOrEmpty(Cr12.FileName))))))
                        {
                            var fileName1 = Path.GetFileName(BoardResolution.FileName);
                            var RegistrationCertificateFileName = Path.GetFileName(RegistrationCertificate.FileName);
                            var Cr12FileName = Path.GetFileName(Cr12.FileName);
                            var PinCertificateFileName = Path.GetFileName(PinCertificate.FileName);


                            //BoardResolution

                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(fileName1) == ".jpg" || Path.GetExtension(fileName1) == ".jpeg" || Path.GetExtension(fileName1) == ".png")
                            {
                                fileName1 = "Rsl" + companyId + fileName1;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", fileName1);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await BoardResolution.CopyToAsync(strea);
                                }

                                var CompanyBoardResolution = companyDocs.BoardResolution = "CompanyFiles/" + fileName1;
                            }

                            //RegistrationCertificate
                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(RegistrationCertificateFileName) == ".jpg" || Path.GetExtension(RegistrationCertificateFileName) == ".jpeg" || Path.GetExtension(RegistrationCertificateFileName) == ".png")
                            {
                                RegistrationCertificateFileName = "RegCert" + companyId + RegistrationCertificateFileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", RegistrationCertificateFileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await RegistrationCertificate.CopyToAsync(strea);
                                }

                                var CompanyRegistrationCertificate = companyDocs.RegistrationCertificate = "CompanyFiles/" + RegistrationCertificateFileName;
                            }

                            //PinCertificate

                            if (Path.GetExtension(PinCertificateFileName) == ".pdf" || Path.GetExtension(PinCertificateFileName) == ".jpg" || Path.GetExtension(PinCertificateFileName) == ".jpeg" || Path.GetExtension(PinCertificateFileName) == ".png")
                            {
                                PinCertificateFileName = "PinCert" + companyId + PinCertificateFileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", PinCertificateFileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await PinCertificate.CopyToAsync(strea);
                                }

                                var CompanyPinCertificate = companyDocs.PinCertificate = "CompanyFiles/" + PinCertificateFileName;
                            }

                            //Cr12

                            if (Cr12FileName != null && Cr12FileName.Length > 0 && !string.IsNullOrEmpty(Cr12FileName))
                            {
                                Cr12FileName = "Cr" + companyId + Cr12FileName;
                                //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                                var uploads = Path.Combine(_env.WebRootPath, "CompanyFiles", Cr12FileName);
                                //var myfilePath = Path.Combine(uploads, fileName);
                                using (var strea = new FileStream(uploads, FileMode.Create))
                                {
                                    await Cr12.CopyToAsync(strea);
                                }

                                var CompanyCr12 = companyDocs.Cr12 = "CompanyFiles/" + Cr12FileName;
                            }
                        }

                        companyDocs.Status = 4;
                        companyDocs.CompanyId = companyId;
                        companyDocs.ApplicantId = Guid.Parse(me.Id);
                        _context.Update(companyDocs);
                         _context.SaveChanges();
                    }
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompanyDocsExists(companyDocs.Id))
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
            return View(companyDocs);
        }

        // GET: CompanyDocs/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companyDocs = await _context.TbCompanyDocs
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companyDocs == null)
            {
                return NotFound();
            }

            return View(companyDocs);
        }

        // POST: CompanyDocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var companyDocs = await _context.TbCompanyDocs.AsNoTracking().SingleOrDefaultAsync(m => m.Id == id);
            _context.TbCompanyDocs.Remove(companyDocs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompanyDocsExists(Guid id)
        {
            return _context.TbCompanyDocs.AsNoTracking().Any(e => e.Id == id);
        }
    }
}

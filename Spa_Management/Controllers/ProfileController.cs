using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Spa_Management.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        private static IHostingEnvironment _env;
        public ProfileController(ApplicationDbContext context,UserManager<ApplicationUser> userManager, IDbOperations operations, IHostingEnvironment hosting)
        {
            _context = context;
            _userManager = userManager;
            _dbOps = operations;
            _env = hosting;
        }
        public async Task<IActionResult> Index()
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            var user = _context.TbUserProfiles.FirstOrDefault(g => g.systemID == me.Id);
            var userBaze = _dbOps.GetUserType(me);
            if (object.ReferenceEquals(user, null))
            {
                user = new tbUserProfiles()
                {
                    profGuid = Guid.NewGuid(),
                    systemID = me.Id,
                    userType = userBaze.type,
                    userGuid = userBaze.gui,
                    photoPath = "",
                    preferedCommMethod = 2,
                    status = 0
                };
                _context.TbUserProfiles.Add(user);
                _context.SaveChanges();
            }
            
            profileView pv = new profileView();
            if(user.userType == 1) // Solo
            {
                var i = _context.TbIndivuduals.FirstOrDefault(k => k.indGuid == user.userGuid);
                pv.name = String.Format("{0} {1} {2}", i.SirName, i.FirstName, i.LastName);
                pv.idNum = i.idNumber;
                pv.pysicalLoc = i.pysicalLoc;
                pv.marital = i.maritalStatus;
                pv.gender = i.gender;
                pv.dob = i.dob;
                //pv.nationality = i.tbNationalities.Nationality ?? "";
               // pv.tbBeneficialies = i.tbBeneficialies;
            }
            else if(user.userType == 2) //Bank
            {
                var i = _context.TbBankUsers.FirstOrDefault(k => k.bankUserGuid == user.userGuid);
                pv.name = String.Format("{0} {1} {2}", i.SirName, i.FirstName, i.LastName);
                pv.idNum = i.idNumber;
                pv.pysicalLoc = i.pysicalLoc;
                pv.marital = i.maritalStatus;
                pv.gender = i.gender;
                pv.dob = i.dob;
                //pv.nationality = i.tbNationalities.Nationality??"";
                pv.Bank = getBank(i.SystemBanksGuid); // i.tbSystemBanks.bankName;
            }
            else if (user.userType == 3) // Company User
            {
                var i = _context.TbCompanyUsers.FirstOrDefault(k => k.compUserGuid == user.userGuid);
                pv.name = String.Format("{0} {1} {2}", i.SirName, i.FirstName, i.LastName);
                pv.idNum = i.idNumber;
                pv.pysicalLoc = i.pysicalLoc;
                pv.marital = i.maritalStatus;
                pv.gender = i.gender;
                pv.dob = i.dob;
                //pv.nationality = i.tbNationalities.Nationality??"";
                pv.Company = getCompany(i.compGuid); // i.tbCompanies.compName;
            }
            pv.photo = user.photoPath;
            pv.phone = me.PhoneNumber;
            pv.email = me.Email;
            pv.preferedCommMethod = user.preferedCommMethod;
            pv.tbApplications = _context.TbApplications.Where(g => g.appliedBy == me.Id).ToList();



            ViewData["CommModes"] = new List<SelectListItem>
                        {
                            new SelectListItem {Text = "Email", Value = "0"},
                            new SelectListItem {Text = "SMS", Value = "1"},
                            new SelectListItem {Text = "Both", Value = "2"}
                        };

            return View(pv);
        }
        public string getCompany(Guid guid)
        {
            return _context.TbCompanies.FirstOrDefault(h => h.compGuid == guid).compName;
        }
        public string getBank(Guid guid)
        {
            return _context.TbSystemBanks.FirstOrDefault(h => h.SystemBanksGuid == guid).bankName;
        }
        public async Task<IActionResult> ChgModePic(string Btn, IFormFile file,string preferedCommMethod)  {
            try
            {
                var me = await _userManager.GetUserAsync(HttpContext.User);
                var user = _context.TbUserProfiles.FirstOrDefault(g => g.systemID == me.Id);
                if (Btn == "chgMode")
                {
                    if (!object.ReferenceEquals(preferedCommMethod, null))
                    {
                        if(preferedCommMethod.Trim() != "~ Please Select ~")
                        {
                            user.preferedCommMethod = Convert.ToInt16(preferedCommMethod);
                        }
                    }
                }if(Btn == "chgPic")
                {
                    if (file != null && file.Length > 0 && !string.IsNullOrEmpty(file.FileName))
                    {
                        var fileName = Path.GetFileName(file.FileName);
                        if (Path.GetExtension(fileName) == ".jpg" || Path.GetExtension(fileName) == ".jpeg" || Path.GetExtension(fileName) == ".png")
                        {
                            fileName = me.Id + fileName;
                            //var path = Path.Combine(_env.WebRootPath + "\\Uploads\\", fileName);
                            var uploads = Path.Combine(_env.WebRootPath, "profPics", fileName);
                            //var myfilePath = Path.Combine(uploads, fileName);
                            using (var strea = new FileStream(uploads, FileMode.Create))
                            {
                                await file.CopyToAsync(strea);
                            }
                            user.photoPath = "profPics/"+fileName;
                        }
                    }
                }
                _context.Update(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
            }
            return RedirectToAction(nameof(Index));
        }
        
    }
    public class profileView
    {
        #region Basics
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Photo")]
        public string photo { get; set; }

        [Display(Name = "ID Number")]
        public string idNum { get; set; }

        [Display(Name = "Phone Number")]
        public string phone { get; set; }

        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Physical Location")]
        public string pysicalLoc { get; set; }

        [Display(Name = "Marital Status")]
        public string marital { get; set; }

        [Display(Name = "Gender")]
        public string gender { get; set; }

        [Display(Name = "DOB")]
        public DateTime dob { get; set; }

        [Display(Name = "Nationality")]
        public string nationality { get; set; }

        public string Company { get; set; }
        public string Bank { get; set; }
        /// <summary>
        /// 0 = Email,
        /// 1 = SMS,
        /// 2 = Both
        /// </summary>
        [Display(Name = "Communication Mode")]
        public int preferedCommMethod { get; set; }
        #endregion
        public List<tbBeneficialies> tbBeneficialies { get; set; }
        public List<tbApplications> tbApplications { get; set; }
        public List<tbCRBChecks> tbCRBChecks { get; set; }
        public List<tbPayMaster> tbPayMaster { get; set; }
        public List<tbPayPesaLink> tbPayPesaLink { get; set; }
    }
}
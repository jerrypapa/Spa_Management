using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Models.AccountViewModels;
using iTextSharp.text.log;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Spa_Management.Controllers
{
    [Produces("application/json")]
    [Route("api/BeneficiaryLogin")]
    public class BeneficiaryLoginController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        AppLoginResponse LoginResponse = new AppLoginResponse();

        public BeneficiaryLoginController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger,
            ApplicationDbContext context,
            IDbOperations dbOps)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
            _dbOps = dbOps;
        }
      
        [HttpPost]
        public async Task<AppLoginResponse> BeneficiaryLogin([FromBody] AppLogin model, string returnUrl = null)
        {
            try
            {

                string fullnames = "";
                if (ModelState.IsValid)
                {
                    var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                      
                    LoginResponse.Code = "000";
                    LoginResponse.Description = "Success";
                    LoginResponse.InstitutionName = "";
                
                    }
                    if (result.IsNotAllowed)
                    {
                        LoginResponse.Code = "0003";
                        LoginResponse.Description = "Please Confirm Your Email";
                        LoginResponse.InstitutionName = "";

                    }
                    if (result.IsLockedOut)
                    {
                        LoginResponse.Code = "0002";
                        LoginResponse.Description = "User Account Is Locked";
                        LoginResponse.InstitutionName = "";
                    }
                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return LoginResponse;
        }

        // PUT: api/BeneficiaryLogin/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

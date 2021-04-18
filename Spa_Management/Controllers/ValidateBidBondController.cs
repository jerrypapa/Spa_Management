using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Spa_Management.Controllers
{
    [Produces("application/json")]
    [Route("api/ValidateBidBond")]
    public class ValidateBidBondController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        // private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        ScanResponse resp = new ScanResponse();

        public ValidateBidBondController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<ValidateBidBondController> logger,
            ApplicationDbContext context,
            IDbOperations dbOps)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //  _logger = logger;
            _context = context;
            _dbOps = dbOps;
        }
      
        // POST: api/ValidateBidBond
        [HttpPost]
        public async Task<ScanResponse> Post([FromBody]ValidateBarCode detail)
        {
            try
            {
                var validate = await _dbOps.ValidateBarCode(detail.BarCode);

                
                return validate;
            }
            catch (Exception ex)
            {
                //log execptions
                throw;
            }
           
        }
        
        // PUT: api/ValidateBidBond/5
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

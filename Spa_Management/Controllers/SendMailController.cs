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
    [Route("api/SendMail")]
    public class SendMailController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        // private readonly ILogger _logger;
        private readonly ApplicationDbContext _context;
        private readonly IDbOperations _dbOps;
        SendMailResponse resp = new SendMailResponse();

        public SendMailController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<SendMailController> logger,
            ApplicationDbContext context,
            IDbOperations dbOps)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //  _logger = logger;
            _context = context;
            _dbOps = dbOps;
        }
       
        
        // POST: api/SendMail
        [HttpPost]
        public async Task<SendMailResponse> Post([FromBody]SendMail details)
        {
            var mailSent = await _dbOps.SendMailMobileApp(details.BarCode, details.Email);
            return mailSent;
        }
        
        // PUT: api/SendMail/5
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

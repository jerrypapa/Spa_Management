using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Spa_Management.Controllers
{
    [Produces("application/json")]
    [Route("api/userDet")]
    public class userDetController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;
        public userDetController(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        // GET: api/userDet
        //[HttpGet]
        //public async Task<string> Get()
        //{
        //    var me = await _userManager.GetUserAsync(HttpContext.User);
        //    return _context.TbUserProfiles.FirstOrDefault(g => g.systemID == me.Id).photoPath;
        //}

        [HttpGet]
        public async Task<string> getUserImage()
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            return _context.TbUserProfiles.FirstOrDefault(g => g.systemID == me.Id).photoPath;
        }
        [HttpGet("{id}", Name = "Get")]
        public async Task<int> Get(int id)
        {
            var me = await _userManager.GetUserAsync(HttpContext.User);
            return _context.TbNotifications.Where(g => g.systemID == me.Id && g.status == 0).Count();
        }
        
        // POST: api/userDet
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/userDet/5
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

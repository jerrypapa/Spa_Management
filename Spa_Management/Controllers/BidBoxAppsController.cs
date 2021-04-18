using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Spa_Management.Data;
using Spa_Management.Dto;
using Spa_Management.Interfaces;
using Spa_Management.Operations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Spa_Management.Controllers
{


    [Produces("application/json")]
    [Route("api/Spa_ManagementApps")]   

    public class Spa_ManagementAppsController : Controller
    {        
        private readonly IDbOperations _dbOps;
        private readonly response _res = new response();
        public Spa_ManagementAppsController(IDbOperations dbOps)
        {
            _dbOps = dbOps;
        }
        // Inject 
        // GET: api/Spa_ManagementApps
        //[HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Githu", "iko sawa" };
        }


        //POST: api/Spa_ManagementApps
        [HttpPost]
        public response Post([FromBody]dynamic _json)
        {
            try
            {
                _dbOps.LogJson(_json.ToString());
				_dbOps.UpdateCheckouStatus((PaymentResponsePost)_json);
				var res = Newtonsoft.Json.JsonConvert.DeserializeObject<PaymentResponsePost>(_json);
				_dbOps.UpdateCheckouStatus(res);
				//Do database operations

			}
            catch (Exception ex)
            {
				throw ex;
            }
            return _res;
        }


    }
    public class inComing
    {
        public string transactionID { get; set; }

        public string merchantreference { get; set; }

        public string ordersummary { get; set; }

        public string email { get; set; }

        public string currency { get; set; }

        public string msisdn { get; set; }

        public double amount { get; set; }

        public string statusCode { get; set; }

        public string statusdDescription { get; set; }

    }
    public class response
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Dto
{
	public class PaymentResponsePost
	{
		//transactionID=&merchantreference=amount=&statusCode=&statusdDescription
		public string transactionID { get; set; }
		public string merchantreference { get; set; }
		public decimal amount { get; set; }
		public string statusCode { get; set; }
		public string statusdDescription { get; set; }
	}
}

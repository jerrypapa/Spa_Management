using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbEmailLogs
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [EmailAddress]
        public string to { get; set; }

        [EmailAddress]
        public string from { get; set; }

        public string subject { get; set; }


        public string cc { get; set; }

        public string bcc { get; set; }

        public string message { get; set; }


        public DateTime date { get; set; }
        /// <summary>
        /// 0 = Deafult
        /// 1 = Sent
        /// 2 = Failed
        /// 3 = Blah Blah......
        /// </summary>
        public int status { get; set; }
    }
}

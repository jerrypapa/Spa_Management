using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbJsonLogs
    {       
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string json { get; set; }

        public DateTime time { get; set; }

        /// <summary>
        /// 0 = new,
        /// </summary>
        public int status { get; set; }
       
    }
}

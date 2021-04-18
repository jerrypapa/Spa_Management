using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models
{
    public class tbApplicationDocs
    {
        [Key]
        public Guid applicationDocsGuid { get; set; }

        //Aplication GUID
        //[Required]
        public Guid CRBGuid { get; set; }

        /// Required Bank Documents
        //[Required]
        public Guid docReqGuid { get; set; }

        [Required]
        [MaxLength(210)]
        public string docPath { get; set; }

        /// <summary>
        /// 0 = Active,
        /// 1 = In-Active
        /// </summary>
        public int status { get; set; }

        public tbApplications tbApplications { get; set; }
        //public tbDocUploadReq tbDocUploadReq { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }

        public tbFeedBacks tbFeedBacks { get; set; }

        public tbIndivuduals tbIndivuduals { get; set; }

        public tbCompanies tbCompanies { get; set; }
        public SpaDetails spaDetails { get; set; }
        public SpaUsers spaUsers { get; set; }

        public tbBeneficiaries tbBeneficiaries { get; set; }
        public tbBeneficiaryEmployees tbBeneficiaryEmployees { get; set; }

        public tbCompanyUsers tbCompanyUsers { get; set; }
    }
}

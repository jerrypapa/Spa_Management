using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Models;

namespace Spa_Management.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<SpaCustomer> SpaCustomers_ { get; set; }
        public virtual DbSet<SpaRoles> SpaRoles { get; set; }
        public virtual DbSet<CompletedJobs> CompletedJobs_ { get; set; }
        public virtual DbSet<Appointments> Appointments_ { get; set; }
        public virtual DbSet<SpaServices> SpaServices_ { get; set; }
        public virtual DbSet<EmployeePay> EmployeePays_ { get; set; }

        public virtual DbSet<tbAudit> TbAudit { get; set; }
        public virtual DbSet<TradePawaCommissionMatrix> TradePawaMatrix { get; set; }
        //public virtual DbSet<tbBanks> TbBanks { get; set; }
        //public virtual DbSet<tbBranches> TbBranches { get; set; }
        public virtual DbSet<tbEmailLogs> TbEmailLogs { get; set; }
        public virtual DbSet<CrmIssueCategory> CrmIssueCategory { get; set; }
        public virtual DbSet<CrmLogs> CrmLogs { get; set; }
        public virtual DbSet<MpesaPayments> MpesaPayments { get; set; }
        public virtual DbSet<SpaDetails> SpaDetails { get; set; }
        public virtual DbSet<SpaUsers> SpaUsers { get; set; }
        public virtual DbSet<EmailBroadCast> EmailBroadCast { get; set; }
        public virtual DbSet<PaymentOptions> PaymentOptions { get; set; }
        public virtual DbSet<tbErrorLogs> TbErrorLogs { get; set; }
        public virtual DbSet<tbGender> TbGenders { get; set; }
        public virtual DbSet<tbIdTypes> TbIdTypes { get; set; }
        public virtual DbSet<CompanyDocs> TbCompanyDocs { get; set; }
        public virtual DbSet<BankSetups> TbBankSetups { get; set; }
        public virtual DbSet<tbIndivuduals> TbIndivuduals { get; set; }
        public virtual DbSet<tbMaritalStatus> TbMaritalStatuses { get; set; }
        public virtual DbSet<tbBondProcessingActions> BondProcessingActions { get; set; }
        public virtual DbSet<PostAmmendMentMatrix> PostAmmendMentMatrix { get; set; }
        public virtual DbSet<tbNationalities> TbNationalities { get; set; }
        public virtual DbSet<tbSMSLogs> TbSMSLogs { get; set; }
        public virtual DbSet<tbSuffixes> TbSuffixes { get; set; }
        public virtual DbSet<tbIPQRSChecks> TbIPQRSChecks { get; set; }
        public virtual DbSet<tbCRBChecks> TbCRBChecks { get; set; }
        public virtual DbSet<tbSystemBanks> TbSystemBanks { get; set; }
        public virtual DbSet<tbSysConfigs> TbSysConfigs { get; set; }
        public virtual DbSet<tbApplications> TbApplications { get; set; }
        public virtual DbSet<tbCompanies> TbCompanies { get; set; }
        public virtual DbSet<tbCompanyUsers> TbCompanyUsers { get; set; }
        public virtual DbSet<tbDesignations> TbDesignations { get; set; }
        public virtual DbSet<tbBankUsers> TbBankUsers { get; set; }
        public virtual DbSet<tbComMatrices> TbComMatrices { get; set; }
        public virtual DbSet<BankAmmendmentMatrices> BankAmmendmentMatrices { get; set; }
        public virtual DbSet<tbCurrencies> TbCurrencies { get; set; }
        public virtual DbSet<tbBeneficialies> TbBeneficialies { get; set; }
        public virtual DbSet<tbDocTypes> TbDocTypes { get; set; }
        public virtual DbSet<tbDocUploadReq> TbDocUploadReqs { get; set; }
        public virtual DbSet<tbApplicationDocs> TbApplicationDocs { get; set; }
        public virtual DbSet<tbUserProfiles> TbUserProfiles { get; set; }
        public virtual DbSet<tbPayMaster> TbPayMasters { get; set; }
        public virtual DbSet<tbPayPesaLink> tbPayPesaLink { get; set; }
        public virtual DbSet<tbNotifications> TbNotifications { get; set; }
        public virtual DbSet<tbFeedBacks> TbFeedBacks { get; set; }
        public virtual DbSet<tbJsonLogs> TbJsonLogs { get; set; }
        public virtual DbSet<tbBankBranches> TbBankBranches { get; set; }
        public virtual DbSet<tbCompanyUserAccessRights> tbCompanyUserAccessRights { get; set; }
        public virtual DbSet<tbBankUserAccessRights> tbBankUserAccessRights { get; set; }
        public virtual DbSet<tbBankUserRoles> tbBankUserRoles { get; set; }
        public virtual DbSet<tbCompanyUserRoles> tbCompanyUserRoles { get; set; }


        public virtual DbSet<tbPaymentRecords> TbPaymentRecords { get; set; }
        public virtual DbSet<tbCommisionShares> TbCommisionShares { get; set; }
        public virtual DbSet<tbBoardResolutions> TbBoardResolutions { get; set; }
        public virtual DbSet<tbDirectors> TbDirectors { get; set; }
        public virtual DbSet<tbBeneficiaryEmployees> TbBeneficiaryEmployees { get; set; }
        public virtual DbSet<tbBeneficiaries> TbBeneficiaries { get; set; }
        public virtual DbSet<tbOtpVerify> Otp { get; set; }
        public virtual DbSet<tbMenus> TbMenus { get; set; }
        public virtual DbSet<BondPrintOptions> BondPrintOptions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);          
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Spa_Management.Models.tbPostalCodes> tbPostalCodes { get; set; }
    }
}

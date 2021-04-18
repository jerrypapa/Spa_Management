using Spa_Management.Dto;
using Spa_Management.Models;
using Spa_Management.Operations;
using System;
using System.Collections.Generic;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
	public interface IDbOperations
	{
        Task<(bool,string)> AddDirector(tbDirectors directorDetails);
        Task<bool> LogCrm(CrmLogs crmDetails);
        Task<ScanResponse> ValidateBarCode(string BarCode);
        Task<SendMailResponse> SendMailMobileApp(string BarCode,string Email);
        Task<bool> AddCompanyRole(tbCompanyUserRoles companyUserRole);
        Task<bool> AddBankRole(tbBankUserRoles bankUserRole);
        Task<bool> LogMpesaPayment(MpesaPayments mpesaPayments);
        Task<bool> UpdatePaymentstatus(MpesaPayments mpesaPayments);
        //Task<bool> GetPaymentReport(MpesaPayments bankUserRole);
        Task<bool> AddCompanyAcessRight(tbCompanyUserAccessRights companyUserAccessRight);
        Task<bool> AddBankAcessRight(tbBankUserAccessRights bankUserAccessRight);
        Task<string> RegisterCompany(tbCompanies companyDetails);
        Task<bool> VerifyDirector(tbDirectors directorDetails);
        Task<tbDirectors> GetDirector(Guid Id);
        bool AcceptAllCertifications(object sender, X509Certificate certification, X509Chain chain, SslPolicyErrors sslPolicyErrors);
		Task AuditOperation(string userId, string action, string desc, string json, string page, string sess = null);
		string Between(string value, string a, string b);
		string CallCompanyWebService(string Consent, string IDNumber, string IDNumberType, string InquiryReason, string ReportDate, string ScoringReport, string SubjectType);
		string CallWebService(string idno, string idtype);
		Task<DbOperations.DetailBeneficiary> DetailOfBeneficiary(tbApplications app);
		Task<DbOperations.DetailOfWhoApplied> DetailsOfWhoApplied(tbApplications app);
		string GenerateRandomPassword();
		Task<List<Guid>> GetAllBankUsers(Guid guid);
		Task<int> GetBankUserAccountStatus(Guid userId);
		Task<string> GetBankUserSysId(Guid id);
		Task<decimal> GetCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod);
        Task<decimal> GetPostAmmendCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod);
        Task<decimal> GetBankPostAmmendCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod);
        Task<decimal> GetBankCommisionAmount(decimal amount, Guid Bank, string curr, string Newperiod);
        Task<string> GetCompanyDetails(Guid guid);
		Task<DbOperations.CompanyRegistrarDetails> GetCompanyRegistrarDetails(tbCompanies comp);
        Task<DbOperations.SpaRegistrarDetails> GetSpaRegistrarDetails(SpaDetails spa);
        Task<DbOperations.BeneficiaryRegistrarDetails> GetBeneficiaryRegistrarDetails(tbBeneficiaries beneficiaries);
		Task<int> GetCompanyUserAccountStatus(Guid userId);
		DateTime GetExpDate(DateTime bonddate, string period);
		Task<int> GetIndUserAccountStatus(Guid userId);
		Task<tbSysConfigs> GetSysParameter(string code);
		Task<string> GetUserRole(Guid guid, int userType);
		Task<string> GetSpaUserRole(Guid guid, int userType);
		DbOperations.UserBase GetUserType(ApplicationUser _user);
		Task<string> GetWhoApplied(Guid guid);
		Task<string> GetWhoApprovedOrChecked(Guid guid, int i);
		Task<DbOperations.IPRSTokenResponse> IPRSTokenRequest(object _obj);
		Task<bool> IsEmailUsed(string email);
		Task<bool> AutoApprove(tbApplications application);
		Task<bool> LogAndSendMail(string ToEmail, string Subj, string Message, string cc = "", string bcc = "");
		Task<bool> LogandSendSMS(string msisdn, string message, string userName, string apiKey, string From);
		Task LogError(string action, string desc, string json, string errMsg, string innerEx, string modelValid = null, string sess = null);
		Task LogJson(string json);
		Task LogNotification(string userId, int type, string mess);
		Task<DbOperations.Response> PostRequest(object _obj, bool Mpesa);
		Task<DbOperations.MpesaResponse> PostLipaNaMpesaRequest(object _obj, bool Mpesa);
		Task<DbOperations.MpesaStatusResponse> PostLipaNaMpesaStatus(object _obj, bool Mpesa);

		Task UpdateCheckouStatus(PaymentResponsePost paymentResponsePost);
	}
}

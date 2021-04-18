using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Spa_Management.Data;
using Spa_Management.Models;
using Spa_Management.Operations;

namespace Spa_Management.Interfaces.Spa
{
    public class SpaOperations : ISpaOperations
    {
        private readonly IEmailSender _emailSender;
        private readonly IDatabaseErrorLogger _databaseErrorLogger;
        private readonly ISystemParameters _systemParameters;
        private readonly IDbOperations _dbOps;
        private readonly ApplicationDbContext _context;
        private readonly ISMSSender _sMSSender;
        private readonly UserManager<ApplicationUser> _userManager;
        public SpaOperations(ApplicationDbContext context, IEmailSender emailSender, IDatabaseErrorLogger databaseErrorLogger, ISystemParameters systemParameters, ISMSSender sMSSender, UserManager<ApplicationUser> manager, IDbOperations dbOperations)
        {
            _context = context;
            _emailSender = emailSender;
            _databaseErrorLogger = databaseErrorLogger;
            _systemParameters = systemParameters;
            _sMSSender = sMSSender;
            _userManager = manager;
            _dbOps = dbOperations;
        }
        public async Task<(bool, string)> RegisterSpa(SpaDetails spaDetails, SpaUsers spaUsers)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(spaUsers.email);

                if (user != null)
                {
                    return (false, "The Applicant email is already used");
                }
                var comp = await _context.SpaDetails.AsNoTracking().SingleOrDefaultAsync(m => m.spaName == spaDetails.spaName);
                if (comp != null)
                {
                    return (false, "This Spa Is already Registered");

                }
                else
                {
                    var address = _context.tbPostalCodes.AsNoTracking().FirstOrDefault(c => c.Code == int.Parse(spaDetails.PostalCode)).RegionName;
                    spaDetails.postalAddress = address ?? "Address";

                    var newSpa = SpaDetails.AddNewSpa(spaDetails.registeredBy, spaDetails.spaName, spaDetails.email, spaDetails.pysicalLoc, spaDetails.postalAddress, spaDetails.PostalCode, spaDetails.PinNo, spaDetails.RegCertNo, spaDetails.contact, spaDetails.incNum);

                    var newUser = SpaUsers.AddNewSpaUser(newSpa.spaGuid, spaUsers.SirName, spaUsers.FirstName, spaUsers.MiddleName, spaUsers.LastName, spaUsers.contact, spaUsers.email, spaUsers.dob, spaUsers.idType, spaUsers.idNumber, spaUsers.pysicalLoc?? newSpa.pysicalLoc);

                    _context.SpaUsers.Add(newUser);

                    newSpa.registeredBy = newUser.spaUserGuid.ToString();

                    _context.Add(newSpa);

                    await _context.SaveChangesAsync();
                    await _dbOps.LogAndSendMail(newUser.email, "Spa Registration", "Dear " + newUser.FirstName + ", Thank you for registering your SPA Business with us. You will receive an email notification once your details have been verified .");
                    await _dbOps.LogandSendSMS(newUser.contact, "Dear " + newUser.FirstName + ", Thank you for registering your SPA Business with us. You will receive an email notification once your details have been verified .", "", "", "");
                    await _dbOps.AuditOperation(spaUsers.spaUserGuid.ToString(), "Spa/Create", "Added a new Business " + spaDetails.spaGuid.ToString(), "", "SpaDetails");
                    return (true, "Successfully Registered Spa");
                }
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Spa/Create", "Add new Business", "", ex.Message.ToString(), ex.InnerException is null ? "" : ex.InnerException.ToString());
                return (false, "Exception");
            }
        }

       
    }
}

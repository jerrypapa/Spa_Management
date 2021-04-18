using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Operations
{
    public class Router : IRouter
    {
        private readonly IEmailSender _emailSender;
        private readonly IDatabaseErrorLogger _databaseErrorLogger;
        private readonly ISystemParameters _systemParameters;
        private readonly ApplicationDbContext _context;
        private readonly ISMSSender _sMSSender;
        private readonly IDbOperations _dbOps;
        public Router(ApplicationDbContext context, IEmailSender emailSender,
            IDatabaseErrorLogger databaseErrorLogger, ISystemParameters systemParameters,
            ISMSSender sMSSender, IDbOperations dbOperations)
        {
            _context = context;
            _emailSender = emailSender;
            _databaseErrorLogger = databaseErrorLogger;
            _systemParameters = systemParameters;
            _sMSSender = sMSSender;
            _dbOps = dbOperations;
        }

        public async Task<bool> ReduceOveralLimit(Guid bankId, decimal AmountToReduce)
        {
            throw new NotImplementedException();
        }

        public async Task<(Guid?, string, Guid?, string,string)> ToRoute(decimal bondValue, string CustomerToPrint)
        {
            try
            {
                string CustomerToPrint2 = null;
                if (!string.IsNullOrWhiteSpace(CustomerToPrint))
                {
                    if (CustomerToPrint == "0350")
                    {
                        CustomerToPrint2 = "1";
                    }
                    else if(CustomerToPrint=="0450")
                    {
                        CustomerToPrint2 = "0";
                    }
                    else
                    {
                        CustomerToPrint2 = "1";
                        //Default to Print
                    }

                }
                tbSystemBanks BankToConsider = null;
                //1. Get banks that allow printing and max limit falls within range

                var BanksAllowPrintingandLimitWithinRange = _context.TbSystemBanks.Where(c => c.MaximumSecurityLimit >= bondValue && c.LimitBalance >= bondValue && c.AllowAutoGene == CustomerToPrint2);
                if (BanksAllowPrintingandLimitWithinRange.Count() == 0)
                {
                    var BankwithLowestPercentage = _context.TbSystemBanks.Where(c => c.MaximumSecurityLimit >= bondValue && c.LimitBalance == bondValue).Include(c => c.tbComMatrices.Min(v => v.perCom));

                    if (BankwithLowestPercentage.Count() == 0)
                    {
                       // BankToConsider = _context.TbSystemBanks.Include(c => c.tbComMatrices.Min(v => v.perCom));
                    }
                    else
                    {

                    };
                }
                else
                {
                    List<tbComMatrices> tbComMatrices = null;
                    var BankToConsider1 = BanksAllowPrintingandLimitWithinRange.Include(c => c.tbComMatrices);

                    var matrixlist = (from items in BankToConsider1
                                     select items.tbComMatrices.Min(kk=>kk.perCom));

                    var min = matrixlist.Min();

                    var comMatricesWithTies = _context.TbComMatrices.Where(c => c.perCom == min).Include(l=>l.tbSystemBanks);

                    if (comMatricesWithTies.Count() > 1)
                    {
                        //There is a tie on per commisions
                        var SelectedBankLimit = comMatricesWithTies.Max(b => b.tbSystemBanks.LimitBalance);
                        var bankSelected = comMatricesWithTies.Where(v => v.tbSystemBanks.LimitBalance == SelectedBankLimit);

                        BankToConsider = bankSelected.FirstOrDefault().tbSystemBanks;

                    }
                    else
                    {
                        BankToConsider =  comMatricesWithTies.FirstOrDefault().tbSystemBanks;
                    }

                }

                Guid bankId;
                Guid branchId;

                // var BankId = _context.TbSystemBanks.Include().Where(c => c.OveralSecuringLimit == banks);

                var Bank = _context.TbSystemBanks.Where(c => c.SystemBanksGuid == BankToConsider.SystemBanksGuid).Include(br => br.tbBankBranches).ToList();
                string BankName = "";
                string BranchName = "";
                if (Bank.Count() > 1)
                {
                    //Deadlock
                    //Split now by

                }
                else
                {
                    bankId = Bank.FirstOrDefault().SystemBanksGuid;
                    BankName = Bank.FirstOrDefault().bankName;

                    var Branch = Bank.FirstOrDefault().tbBankBranches;
                    branchId = Branch.FirstOrDefault().BranchGuid;
                    BranchName = Branch.FirstOrDefault().branchName;
                }

                // Tuple x = new Tuple(bankId, BankName, branchId, BranchName, "Success");

                return (bankId, BankName, branchId, BranchName, "Success"); //(bankId, "", branchId, "");
            }
            catch (Exception ex)
            {
                await _dbOps.LogError("Applications/Create", "Transaction Routing", "", ex.Message.ToString(), ex.InnerException is null ? "N/A" : ex.InnerException.ToString());
                //Log errlors
                return (null, "", null, "", "No route matches bond details provided,please select a different Bond collect Option or try with a lower bond value");
            }

        }
        static decimal Max(params decimal[] numbers)
        {
            return numbers.Max();
        }

        //public Task<(Guid, string, Guid, string)> ToRoute(decimal bondValue, bool CustomerToPrint)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

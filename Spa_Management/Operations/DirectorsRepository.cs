using Spa_Management.Data;
using Spa_Management.Interfaces;
using Spa_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Operations
{
    public class DirectorsRepository : IDirectorsRepository
    {
        private readonly IEmailSender _emailSender;
        private readonly IDatabaseErrorLogger _databaseErrorLogger;
        private readonly ISystemParameters _systemParameters;
        private readonly ApplicationDbContext _context;
        private readonly ISMSSender _sMSSender;
        public DirectorsRepository(ApplicationDbContext context, IEmailSender emailSender,
            IDatabaseErrorLogger databaseErrorLogger, ISystemParameters systemParameters,
            ISMSSender sMSSender)
        {
            _context = context;
            _emailSender = emailSender;
            _databaseErrorLogger = databaseErrorLogger;
            _systemParameters = systemParameters;
            _sMSSender = sMSSender;
        }
        public Task<bool> AddDirector(tbDirectors directorDetails)
        {
            throw new NotImplementedException();
        }

        public Task<tbDirectors> GetDirector(Guid Id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> VerifyDirector(tbDirectors directorDetails)
        {
            throw new NotImplementedException();
        }
        public class insertRespo
        {
            public bool status { get; set; }
            public List<string> desc { get; set; }
        }
    }
}

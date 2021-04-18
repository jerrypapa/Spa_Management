using Spa_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.Interfaces
{
    interface IDirectorsRepository
    {
        Task<bool> AddDirector(tbDirectors directorDetails);
        Task<bool> VerifyDirector(tbDirectors directorDetails);
        Task<tbDirectors> GetDirector(Guid Id);

    }
}

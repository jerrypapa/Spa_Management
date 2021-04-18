using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spa_Management.DocGen
{
    public interface IBondGen
    {
        Task<bool> GenerateDoc(string BondHeader, string BodyOne, string Body2);
    }
}

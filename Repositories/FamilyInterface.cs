using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;

namespace Plantas.Repositories
{
    public interface FamilyInterface
    {
        Task CreateFamily(Family family);
        Task UpdateFamily(Family family);
        Task DeleteFamily (string id);
        Task<Family> GetFamily (string id);
    }
}
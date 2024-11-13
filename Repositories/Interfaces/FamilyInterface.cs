using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;

namespace Plantas.Repositories
{
    public interface FamilyInterface<T>
    {
        Task CreateFamily(T modelo);
        Task UpdateFamily(T modelo);
        Task DeleteFamily (string Id);
        Task<T> GetFamily (string Id);

    }
}
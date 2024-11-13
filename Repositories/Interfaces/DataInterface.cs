using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;
namespace Plantas.Repositories
{
    public interface DataInterface<T> // Interface implementation of cruds
    {
        Task Insert(T Model);
        Task Update(T Model);
        Task Delete(string Id);
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
    }
}
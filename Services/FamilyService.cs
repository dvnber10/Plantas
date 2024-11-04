using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using Plantas.Models;
using Plantas.Repositories;

namespace Plantas.Services
{
    public class FamilyService
    {
        private FamilyInterface db = new FamilyCollection();

        public Task<Family> GetFamily(string Id)
        {
            try
            {
                var family = db.GetFamily(Id);
                if (family == null)
                {
                    return null;
                }
                else
                {
                    return family;
                }
            }
            catch (System.Exception)
            {
                return null;
                throw;
            }
        }
    }
}
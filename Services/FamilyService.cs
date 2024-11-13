using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Plantas.Models;
using Plantas.Repositories;
using Plantas.Repositories.Interfaces;

namespace Plantas.Services
{
    public class FamilyService
    {
        private readonly FamilyInterface<Family> _db;
        private readonly VerInterface _dba;
        public FamilyService(Context context)
        {
            _db = new FamilyCollection(context);
            _dba = new FamilyCollection(context);
        }
        // show one family
        public Task<Family> GetFamily(string Id)
        {
            try
            {
                return _db.GetFamily(Id);
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"Algo fallo {ex.Message}");
            }
        }

        // 
        public async Task<bool> AddFamily(Family family)
        {
            try
            {
                await _db.CreateFamily(family);
                return true;
            }
            catch (System.Exception ex)
            {
                throw new ApplicationException($"Algo fallo {ex.Message}");
            }
        }
    }
}
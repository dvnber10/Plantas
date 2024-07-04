using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Repositories;
using ZstdSharp.Unsafe;
using Plantas.Models;
using Microsoft.AspNetCore.Http.HttpResults;

namespace Plantas.Services
{
    public class TargetService
    {
        public readonly DataCollection _db;
        public TargetService(DataCollection db){
            _db = db;
        }
        public async Task InsertarPlanta(Plant planta){
            try
            {
                await _db.InsertPlant(planta);
                
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<List<Plant>> GetPlants(){
            
            return await _db.GetAllPlants();
           
        }
    }
}
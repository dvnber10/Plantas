using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Repositories;

namespace Plantas.Services
{
    public class TargetService : IData
    {
        private DataInterface _db = new DataInterface();
        

        public async Task GetTargetsAsync()
        {
            return await _db.GetAllPlants();
        }
        public async Task<Plant> InsertPlant(Plant plant){
            if (plant == null){
                return null;
            }
            try
            {
                return await _db.InsertPlant(plant);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex);
                throw;
            }
        }

    }
}
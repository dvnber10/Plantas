using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;
namespace Plantas.Repositories
{
    public interface IData
    {
        Task InsertPlant(Plant plant);
        Task UpdatePlant(Plant plant);
        Task  DeletePlant(string plantId);
        Task <List<Plant>>GetAllPlants();
        Task <Plant> GetPlantById(int id);
        Task<Plant> GetPlantByType(string plantType);

    }
}
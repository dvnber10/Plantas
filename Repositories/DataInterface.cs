using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Plantas.Models;
namespace Plantas.Repositories
{
    public interface DataInterface
    {
        Task InsertPlant(Plant plant);
        Task UpdatePlant(Plant plant);
        Task  DeletePlant(string Id);
        Task <List<Plant>>GetAllPlants();
        Task <Plant> GetPlantById(string id);

    }
}
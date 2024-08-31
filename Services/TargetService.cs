using Plantas.Repositories;
using Plantas.Models;
using Plantas.DTO;
using Plantas.Utilities;
using dotenv.net;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;

namespace Plantas.Services
{
    public class TargetService
    {
        private DataInterface db = new DataCollection();
        private readonly ImageUtility _uti;

        public TargetService(ImageUtility uti)
        {
            _uti = uti;
        }

        public async Task<bool> InsertarPlanta(PlantDTO planta)
        {
            try
            {
                //subir Imagen a cloud
#pragma warning disable CS8604 // Possible null reference argument.
                var route = _uti.ImageUpload(planta.Image);
#pragma warning restore CS8604 // Possible null reference argument.
                DotEnv.Load(options: new DotEnvOptions(probeForEnv: true));
                Cloudinary cloudinary = new(Environment.GetEnvironmentVariable("CLOUDINARY_URL"));
                cloudinary.Api.Secure = true;
                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(@"" + route.Result),
                    UseFilename = true,
                    UniqueFilename = false,
                    Overwrite = true
                };
                var uploadResult = cloudinary.Upload(uploadParams);
#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
                //guardar Url de la imagen para la base de datos
                string urlImage = Convert.ToString(uploadResult.SecureUrl);
                string IdImage = Convert.ToString(uploadResult.PublicId);
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.
                //convertir del DTO a el modelo 
                var plant = new Plant
                {
                    Name = planta.Name,
                    Description = planta.Description,
                    Imagen = urlImage,
                    IdImagen = IdImage
                };
                //Insertar en la base de datos la url de la imagen 
                await db.InsertPlant(plant);
                File.Delete(route.Result);
                return true;
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        public async Task<List<Plant>> GetPlants()
        {

            return await db.GetAllPlants();

        }
        public async Task<Plant> VerPlanta(string id)
        {
            try
            {
                var plantaActual = await db.GetPlantById(id);
                return plantaActual;
            }
            catch(System.Exception e)
            {
                var plantaActual = new Plant{
                    Name= " ",
                    Description = "No Existe La Planta que estas buscando "+e
                };
                return plantaActual;
            }
        }
    }


}
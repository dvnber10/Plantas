using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Plantas.Utilities
{
    public class ImageUtility
    {
          public async Task<string> ImageUpload(IFormFile img){
            var Name = Guid.NewGuid().ToString()+".jpg";
            string Route = $"Upload/{Name}";
            using (var stream = new FileStream(Route,FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }
            return Route;
        }
    }
}
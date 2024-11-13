using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Plantas.Models
{
    public class MongoConnections
    {
        [Required]
        public string ConnectionStrings { get; set; } = string.Empty;
        [Required]
        public string DatabaseName { get; set; } = string.Empty;
    }
}
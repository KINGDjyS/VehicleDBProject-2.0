using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMVC.Models
{
    public class VehicleModelDTO
    {
        public int VehicleModelId { get; set; }

        public int VehicleMakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public virtual VehicleService.VehicleMake VehicleMake { get; set; }
    }
}

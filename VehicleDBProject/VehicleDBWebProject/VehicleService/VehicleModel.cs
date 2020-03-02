using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleService
{
    public class VehicleModel : IVehicleModel
    {
        public VehicleModel()
        {

        }

        [Key]
        public int VehicleModelId { get; set; }

        public int VehicleMakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public virtual VehicleMake VehicleMake { get; set; }
    }
}

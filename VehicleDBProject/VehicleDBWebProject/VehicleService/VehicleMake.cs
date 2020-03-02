using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleService
{
    public class VehicleMake : IVehicleMake
    {
        public VehicleMake()
        {

        }

        [Key]
        public int VehicleMakeId { get; set; }
        public string Name { get; set; }

        public string Abrv { get; set; }
    }
}

using System.Collections.Generic;

namespace VehicleService
{
    public interface IVehicleMake
    {
        string Abrv { get; set; }
        string Name { get; set; }
        int VehicleMakeId { get; set; }
    }
}
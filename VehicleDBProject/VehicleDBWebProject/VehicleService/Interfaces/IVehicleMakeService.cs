using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleService
{
    public interface IVehicleMakeService
    {
        Task<VehicleMake> AddVehicleMakerAsync(VehicleMake vehicleMake);
        Task<VehicleMake> DeleteVehicleMakerAsync(int id);
        Task<VehicleMake> GetOneVehicleMakerAsync(int id);
        IEnumerable<VehicleMake> GetVehicleMakes(string query);
        Task<VehicleMake> UpdateAsync(VehicleMake makeChanged);
        bool HasNameInDatabase(string name);
        IEnumerable<VehicleMake> FilteringQuery(string name);
        bool MakeIdExist(int id);
        int CountMakers();
    }
}
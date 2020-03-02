using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleService
{
    public interface IVehicleModelService
    {
        Task<VehicleModel> AddVehicleModelAsync(VehicleModel vehicleModel);
        Task<VehicleModel> DeleteVehicleModelAsync(int id);
        Task<VehicleModel> GetOneVehicleModelAsync(int id);
        IQueryable<VehicleModel> GetVehicleModels(string query);
        IEnumerable<VehicleMake> GetMakes();
        Task<VehicleModel> UpdateAsync(VehicleModel modelChanged);
        bool HasNameInDatabase(string name);
        IEnumerable<VehicleModel> FilteringQuery(string name);
        bool MakeIdExist(int id);
        int CountModels();
        
    }
}
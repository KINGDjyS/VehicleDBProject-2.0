using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleService
{
    public class VehicleModelService : IVehicleModelService
    {
        private readonly VehicleDBContext _VehicleDB;
        public VehicleModelService(VehicleDBContext vehicleDb)
        {
            _VehicleDB = vehicleDb;
        }

        public async Task<VehicleModel> AddVehicleModelAsync(VehicleModel vehicleModel)
        {
            using (var db = _VehicleDB)
            {
                db.VehicleModels.Add(vehicleModel);
                await db.SaveChangesAsync();
                return vehicleModel;
            }

        }

        public IQueryable<VehicleModel> GetVehicleModels(string query)
        {
            return _VehicleDB.VehicleModels.FromSqlRaw(query);
        }

        public async Task<VehicleModel> DeleteVehicleModelAsync(int id)
        {
            using (var db = _VehicleDB)
            {
                VehicleModel model = db.VehicleModels.Find(id);
                db.VehicleModels.Remove(model);
                await db.SaveChangesAsync();
                return model;
            }
        }

        public async Task<VehicleModel> GetOneVehicleModelAsync(int id)
        {
            return await _VehicleDB.VehicleModels.FromSqlRaw("SELECT * FROM dbo.VehicleModels Where Id = {0}", id).FirstOrDefaultAsync();
        }

        public async Task<VehicleModel> UpdateAsync(VehicleModel makeChanged)
        {
            using (var db = _VehicleDB)
            {
                var model = db.VehicleModels.Attach(makeChanged);
                model.State = EntityState.Modified;
                await db.SaveChangesAsync();
                return makeChanged;
            }
        }

        public IEnumerable<VehicleMake> GetMakes()
        {
            return _VehicleDB.VehicleMakes.ToList();
        }

        public bool HasNameInDatabase(string name)
        {
            return _VehicleDB.VehicleModels.Any(n => n.Name == name);
        }

        public IEnumerable<VehicleModel> FilteringQuery(string name)
        {
            return _VehicleDB.VehicleModels.FromSqlRaw("SELECT * FROM dbo.VehicleModels Where Name = {0}", name).AsEnumerable();
        }

        public bool MakeIdExist(int id)
        {
            return _VehicleDB.VehicleModels.Any(i => i.VehicleModelId == id);
        }

        public int CountModels()
        {
            return _VehicleDB.VehicleModels.Count<VehicleModel>();
        }
    }
}

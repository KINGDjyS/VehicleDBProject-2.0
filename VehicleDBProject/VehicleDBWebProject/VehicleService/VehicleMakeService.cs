using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VehicleService
{
    public class VehicleMakeService : IVehicleMakeService
    {
        private readonly VehicleDBContext _VehicleDB;
        public VehicleMakeService(VehicleDBContext vehicleDB)
        {
            _VehicleDB = vehicleDB;
        }

        public async Task<VehicleMake> AddVehicleMakerAsync(VehicleMake vehicleMake)
        {
            using (var db = _VehicleDB)
            {
                db.VehicleMakes.Add(vehicleMake);
                await db.SaveChangesAsync();
                return vehicleMake;
            }

        }

        public IEnumerable<VehicleMake> GetVehicleMakes(string query)
        {
            return _VehicleDB.VehicleMakes.FromSqlRaw(query);
        }

        public async Task<VehicleMake> DeleteVehicleMakerAsync(int id)
        {
            using (var db = _VehicleDB)
            {
                VehicleMake make = db.VehicleMakes.Find(id);
                db.VehicleMakes.Remove(make);
                await db.SaveChangesAsync();
                return make;
            }
        }

        public async Task<VehicleMake> GetOneVehicleMakerAsync(int id)
        {
            return await _VehicleDB.VehicleMakes.FromSqlRaw("SELECT * FROM dbo.VehicleMakers Where Id = {0}", id).FirstOrDefaultAsync();
        }

        public async Task<VehicleMake> UpdateAsync(VehicleMake makeChanged)
        {
            using (var db = _VehicleDB)
            {
                var make = db.VehicleMakes.Attach(makeChanged);
                make.State = EntityState.Modified;
                await db.SaveChangesAsync();
                return makeChanged;
            }
        }

        public bool MakeIdExist(int id)
        {
            return _VehicleDB.VehicleMakes.Any(i => i.VehicleMakeId == id);
        }

        public IEnumerable<VehicleMake> FilteringQuery(string name)
        {
            return _VehicleDB.VehicleMakes.FromSqlRaw("SELECT * FROM dbo.VehicleMakers Where Name = {0}", name).AsEnumerable();
        }

        public bool HasNameInDatabase(string name)
        {
            return _VehicleDB.VehicleMakes.Any(n => n.Name == name);
        }

        public int CountMakers()
        {
            return _VehicleDB.VehicleMakes.Count<VehicleMake>();
        }

    }
}

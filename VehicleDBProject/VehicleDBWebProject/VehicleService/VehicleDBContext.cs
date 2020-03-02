using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleService
{
    public class VehicleDBContext : DbContext
    {
        private readonly IVehicleMake VehicleMake;
        private readonly IVehicleModel VehicleModel;
        public VehicleDBContext()
        {
        }
        public VehicleDBContext(DbContextOptions<VehicleDBContext> options, IVehicleMake vehicleMake, IVehicleModel vehicleModel) : base(options)
        {
            VehicleMake = vehicleMake;
            VehicleModel = vehicleModel;
        }

        //Mozda Mapper za ovo
        //public DbSet<IVehicleMake> VehicleMakes { get; set; }
        //public DbSet<IVehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server = (localDB)\\mssqllocaldb; Database = VehicleDBContext; Trusted_Connection = True; MultipleActiveResultSets = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VehicleMake>().ToTable("VehicleMakers");

            modelBuilder.Entity<VehicleMake>().HasData(
                new VehicleMake { VehicleMakeId = 1, Name = "Bmw", Abrv = "BMW" },
                new VehicleMake { VehicleMakeId = 2, Name = "Jaguar", Abrv = "JAG" },
                new VehicleMake { VehicleMakeId = 3, Name = "Ford", Abrv = "FRD" },
                new VehicleMake { VehicleMakeId = 4, Name = "Nissan", Abrv = "NIS" },
                new VehicleMake { VehicleMakeId = 5, Name = "VolksWagen", Abrv = "VW" }
                );

            modelBuilder.Entity<VehicleModel>().ToTable("VehicleModels");

            modelBuilder.Entity<VehicleModel>().HasData(
                new VehicleModel { VehicleModelId = 1, VehicleMakeId = 5, Name = "Touareg2", Abrv = "TO2" },
                new VehicleModel { VehicleModelId = 2, VehicleMakeId = 1, Name = "340 Gran Turismo", Abrv = "340" },
                new VehicleModel { VehicleModelId = 3, VehicleMakeId = 3, Name = "F-150", Abrv = "F15" },
                new VehicleModel { VehicleModelId = 4, VehicleMakeId = 2, Name = "XE", Abrv = "XE" },
                new VehicleModel { VehicleModelId = 5, VehicleMakeId = 4, Name = "GT-R", Abrv = "GTR" },
                new VehicleModel { VehicleModelId = 6, VehicleMakeId = 3, Name = "Focus", Abrv = "FCS" },
                new VehicleModel { VehicleModelId = 7, VehicleMakeId = 1, Name = "M550", Abrv = "550" },
                new VehicleModel { VehicleModelId = 8, VehicleMakeId = 5, Name = "Jetta GLI", Abrv = "GLI" },
                new VehicleModel { VehicleModelId = 9, VehicleMakeId = 4, Name = "350Z", Abrv = "350" },
                new VehicleModel { VehicleModelId = 10, VehicleMakeId = 2, Name = "I-Pace", Abrv = "IPC" },
                new VehicleModel { VehicleModelId = 11, VehicleMakeId = 4, Name = "Frontier", Abrv = "FRN" },
                new VehicleModel { VehicleModelId = 12, VehicleMakeId = 2, Name = "F-Type Coupe", Abrv = "FTP" },
                new VehicleModel { VehicleModelId = 13, VehicleMakeId = 3, Name = "Mustang", Abrv = "MST" },
                new VehicleModel { VehicleModelId = 14, VehicleMakeId = 5, Name = "Arteon", Abrv = "ART" },
                new VehicleModel { VehicleModelId = 15, VehicleMakeId = 1, Name = "228 Gran Coupe", Abrv = "228" }
                );
        }

        /*private static DbContextOptions GetOptions(string connectionString)
        {
            var modelBuilder = new DbContextOptionsBuilder();
            return modelBuilder.UseSqlServer(connectionString).Options;
        }*/
    }
}

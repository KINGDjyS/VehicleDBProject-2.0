using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VehicleMVC
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<VehicleService.VehicleMake, Models.VehicleMakeDTO>().ReverseMap();
            CreateMap<VehicleService.VehicleModel, Models.VehicleModelDTO>().ReverseMap();
        }
    }
}

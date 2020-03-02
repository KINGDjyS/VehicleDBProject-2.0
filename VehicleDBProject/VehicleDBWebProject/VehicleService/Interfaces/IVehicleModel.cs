namespace VehicleService
{
    public interface IVehicleModel
    {
        string Abrv { get; set; }
        string Name { get; set; }
        VehicleMake VehicleMake { get; set; }
        int VehicleMakeId { get; set; }
        int VehicleModelId { get; set; }
    }
}
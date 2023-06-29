using System;
namespace UnicoVehicle.DTO
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public VehicleVariant VehicleVariant { get; set; }
        public TransmissionType TransmissionType { get; set; }
        public FuelType FuelType { get; set; }
        public VehicleType VehicleType { get; set; }
        public CylinderArrangement CylinderArrangement { get; set; }
        public VehicleName VehicleName { get; set; }
        public int Doors { get; set; }
        public int Passenger { get; set; }
        public int Cylinder { get; set; }
        public int EngineSize { get; set; }
        public double HorsePower { get; set; }
        public double Torque { get; set; }
        public double Mileage { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Length { get; set; }
        public double GroundClearance { get; set; }
        public double WheelBase { get; set; }
        public double FuelTankSize { get; set; }
        public double KerbWeight { get; set; }
        public double GrossWeight { get; set; }
        public VehicleFeatures VehicleFeatures { get; set; }
    }
}

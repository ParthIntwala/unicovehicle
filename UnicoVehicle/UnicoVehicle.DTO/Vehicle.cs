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
        public float HorsePower { get; set; }
        public float Torque { get; set; }
        public float Mileage { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }
        public float GroundClearance { get; set; }
        public float WheelBase { get; set; }
        public float FuelTankSize { get; set; }
        public float KerbWeight { get; set; }
        public float GrossWeight { get; set; }
    }
}

import './FuelType.dart';
import './CylinderArrangement.dart';
import './VehicleName.dart';
import './VehicleType.dart';
import './TransmissionType.dart';
import './VehicleVariant.dart';
import './VehicleFeatures.dart';

class Vehicle {
  final int vehicleId;
  final VehicleVariant vehicleVariant;
  final TransmissionType transmissionType;
  final FuelType fuelType;
  final VehicleType vehicleType;
  final CylinderArrangement cylinderArrangement;
  final VehicleName vehicleName;
  final int doors;
  final int passenger;
  final int cylinder;
  final int engineSize;
  final double horsePower;
  final double torque;
  final double mileage;
  final double height;
  final double width;
  final double length;
  final double groundClearance;
  final double wheelBase;
  final double fuelTankSize;
  final double kerbWeight;
  final double grossWeight;
  final VehicleFeatures vehicleFeatures;

  Vehicle({
    this.cylinder,
    this.cylinderArrangement,
    this.doors,
    this.engineSize,
    this.fuelTankSize,
    this.fuelType,
    this.grossWeight,
    this.groundClearance,
    this.height,
    this.horsePower,
    this.kerbWeight,
    this.length,
    this.mileage,
    this.passenger,
    this.torque,
    this.transmissionType,
    this.vehicleFeatures,
    this.vehicleId,
    this.vehicleName,
    this.vehicleType,
    this.vehicleVariant,
    this.wheelBase,
    this.width,
  });
}

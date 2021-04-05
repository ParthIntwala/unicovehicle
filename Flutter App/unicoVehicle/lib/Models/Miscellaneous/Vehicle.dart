import '../VehicleVariant.dart';
import '../VehicleName.dart';

class Vehicle {
  final int? vehicleId;
  final VehicleVariant? vehicleVariant;
  final VehicleName? vehicleName;

  Vehicle({
    this.vehicleId,
    this.vehicleName,
    this.vehicleVariant,
  });
}

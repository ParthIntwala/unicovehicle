import './Miscellaneous/Showroom.dart';
import './Miscellaneous/Vehicle.dart';

class VehicleStock {
  final int? vehicleStockId;
  final Showroom? showroom;
  final Vehicle? vehicle;
  final int? stock;

  VehicleStock({
    this.showroom,
    this.stock,
    this.vehicle,
    this.vehicleStockId,
  });
}

import './Miscellaneous/Showroom.dart';
import './Miscellaneous/Vehicle.dart';

class VehiclePrice {
  final int vehiclePriceId;
  final Showroom showroom;
  final Vehicle vehicle;
  final double price;

  VehiclePrice({
    this.price,
    this.showroom,
    this.vehicle,
    this.vehiclePriceId,
  });
}

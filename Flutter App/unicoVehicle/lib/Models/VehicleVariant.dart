import './Miscellaneous/Company.dart';

class VehicleVariant {
  final int? vehicleVariantId;
  final String? vehicleVariant;
  final Company? company;

  VehicleVariant({
    this.company,
    this.vehicleVariant,
    this.vehicleVariantId,
  });
}

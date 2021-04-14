import './AccessoriesBrand.dart';
import './AccessoriesType.dart';
import './VehicleName.dart';

class Accessories {
  final int? accessoriesId;
  final AccessoriesBrand? accessoriesBrand;
  final AccessoriesType? accessoriesType;
  final VehicleName? vehicleName;
  final String accessoriesName;
  final double price;

  Accessories({
    this.accessoriesBrand,
    this.accessoriesId,
    required this.accessoriesName,
    this.accessoriesType,
    required this.price,
    this.vehicleName,
  });
}

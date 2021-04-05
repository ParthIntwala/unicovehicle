import './Miscellaneous/Company.dart';
import './Miscellaneous/District.dart';

class Showroom {
  final int? showroomId;
  final Company? company;
  final District? district;
  final String? showroomName;
  final String? address;
  final String? manager;
  final int? pincode;
  final bool? hasSales;
  final bool? hasService;
  final bool? isOperational;

  Showroom({
    this.address,
    this.company,
    this.district,
    this.hasSales,
    this.hasService,
    this.isOperational,
    this.manager,
    this.pincode,
    this.showroomId,
    this.showroomName,
  });
}

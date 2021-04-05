import './Miscellaneous/User.dart';
import './Miscellaneous/District.dart';

class Customer {
  final int? customerId;
  final User? user;
  final District? district;
  final String? address;
  final String? photograph;
  final String? drivingLicenseNumber;
  final String? standardIDNumber;
  final String? incomeTaxIDNumber;
  final String? lastITReturn;
  final String? bankPassbookPhoto;

  Customer({
    this.address,
    this.bankPassbookPhoto,
    this.customerId,
    this.district,
    this.drivingLicenseNumber,
    this.incomeTaxIDNumber,
    this.lastITReturn,
    this.photograph,
    this.standardIDNumber,
    this.user,
  });
}

import './Miscellaneous/District.dart';

class Company {
  final int? companyId;
  final District? district;
  final String? companyName;
  final String? companyHead;

  Company({
    this.companyHead,
    this.companyId,
    this.companyName,
    this.district,
  });
}

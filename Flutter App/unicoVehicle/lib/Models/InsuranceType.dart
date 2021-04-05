import './Miscellaneous/InsuranceCompany.dart';

class InsuranceType {
  final int? insuranceTypeId;
  final String? insuranceType;
  final InsuranceCompany? insuranceCompany;

  InsuranceType({
    this.insuranceCompany,
    this.insuranceType,
    this.insuranceTypeId,
  });
}

import './Miscellaneous/District.dart';

class InsuranceCompany {
  final int insuranceCompanyId;
  final District district;
  final String address;
  final String countryHead;
  final String companyName;

  InsuranceCompany({
    this.address,
    this.companyName,
    this.countryHead,
    this.district,
    this.insuranceCompanyId,
  });
}

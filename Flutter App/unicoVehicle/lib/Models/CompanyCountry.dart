import './Miscellaneous/Company.dart';
import './Miscellaneous/District.dart';

class CompanyCountry {
  final int companyCountryId;
  final Company company;
  final District district;
  final String countryHead;
  final bool isOperational;

  CompanyCountry({
    this.company,
    this.companyCountryId,
    this.countryHead,
    this.district,
    this.isOperational,
  });
}

import './Country.dart';
import './Miscellaneous/Company.dart';
import './Miscellaneous/District.dart';

class CompanyCountry {
  final int? companyCountryId;
  final Company? company;
  final District? district;
  final Country? country;
  final String? countryHead;
  final bool? isOperational;

  CompanyCountry({
    this.company,
    this.companyCountryId,
    this.country,
    this.countryHead,
    this.district,
    this.isOperational,
  });
}

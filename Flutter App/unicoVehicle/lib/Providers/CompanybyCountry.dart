import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/CompanyCountry.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Country.dart';
import '../Models/Miscellaneous/District.dart';

class CompanybyCountryProvider extends ChangeNotifier {
  Future<List<CompanyCountry>> fetchCompanies(int id) async {
    List<CompanyCountry> companies = [];
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.companybyCountry}/$id"));

      if (response.body.isEmpty) {
        return companies;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<CompanyCountry> loadedcompanies = [];

      body
          .map(
            (company) => loadedcompanies.add(
              CompanyCountry(
                company: new Company(
                  company: company["company"]["companyName"],
                  companyId: company["company"]["companyId"],
                ),
                companyCountryId: company["companyCountryId"],
                countryHead: company["countryHead"],
                isOperational: company["isOperational"],
                district: new District(
                  district: company["district"]["districtName"],
                  districtId: company["district"]["districtId"],
                ),
                country: new Country(
                  country: company["country"]["countryName"],
                  countryId: company["country"]["countryId"],
                ),
              ),
            ),
          )
          .toList();

      return loadedcompanies;
    } catch (err) {
      throw err;
    }
  }
}

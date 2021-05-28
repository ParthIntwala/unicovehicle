import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/CompanyCountry.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/Company.dart';
import '../Models/Miscellaneous/District.dart';

class CompanyCountryProvider extends ChangeNotifier {
  Future<void> addCompanyCountry(CompanyCountry companyCountry) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.companyCountry),
        body: json.encode({
          "district": {
            "districtId": companyCountry.district?.districtId,
          },
          "company": {
            "companyId": companyCountry.company?.companyId,
          },
          "isOperational": companyCountry.isOperational,
          "CountryHead": companyCountry.countryHead,
        }),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> updateCompanyCountry(
      int id, CompanyCountry companyCountry) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.companyCountry}/$id"),
        body: json.encode({
          "district": {
            "districtId": companyCountry.district?.districtId,
          },
          "isOperational": companyCountry.isOperational,
          "CountryHead": companyCountry.countryHead,
        }),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> deleteCompanyCountry(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.companyCountry}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<CompanyCountry> getCompanyCountry(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.companyCountry}/$id"));
      CompanyCountry companyCountry = new CompanyCountry();
      var body = jsonDecode(response.body);

      if (body["insuranceTypeId"] == 0) {
        return companyCountry;
      }

      companyCountry = CompanyCountry(
        companyCountryId: body["companyCountryId"],
        countryHead: body["countryHead"],
        company: Company(
          companyId: body["company"]["companyId"],
          company: body["company"]["companyName"],
        ),
        district: District(
          district: body["district"]["districtName"],
          districtId: body["district"]["districtId"],
        ),
      );

      return companyCountry;
    } catch (err) {
      throw err;
    }
  }
}

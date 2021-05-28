import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/InsuranceCompany.dart';
import '../Models/Miscellaneous/District.dart';
import '../Utilities/BaseURL.dart';

class InsuranceCompanyProvider extends ChangeNotifier {
  Future<InsuranceCompany> fetchInsuranceCompany(int id) async {
    InsuranceCompany company = new InsuranceCompany();
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.insuranceCompany}/$id"));
      var body = jsonDecode(response.body);

      if (body["insuranceCompanyId"] == 0) {
        return company;
      }

      company = InsuranceCompany(
        address: body["address"],
        companyName: body["insuranceCompanyName"],
        insuranceCompanyId: body["insuranceCompanyId"],
        countryHead: body["countryHead"],
        district: new District(
          district: body["district"]["districtName"],
          districtId: body["district"]["districtId"],
        ),
      );

      return company;
    } catch (err) {
      throw err;
    }
  }

  Future<void> addInsuranceCompany(InsuranceCompany insuranceCompany) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.insuranceCompany),
        body: json.encode(
          {
            "district": {
              "DistrictId": insuranceCompany.district?.districtId,
            },
            "insuranceCompanyName": insuranceCompany.companyName,
            "address": insuranceCompany.address,
            "countryHead": insuranceCompany.countryHead,
          },
        ),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> updateInsuranceCompany(
      InsuranceCompany insuranceCompany, int id) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.insuranceCompany}/$id"),
        body: json.encode(
          {
            "district": {
              "DistrictId": insuranceCompany.district?.districtId,
            },
            "insuranceCompanyName": insuranceCompany.companyName,
            "address": insuranceCompany.address,
            "countryHead": insuranceCompany.countryHead,
          },
        ),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<void> deleteAccessoriesBrand(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.insuranceCompany}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

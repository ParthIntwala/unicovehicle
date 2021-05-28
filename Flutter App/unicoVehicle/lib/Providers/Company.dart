import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Company.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/District.dart';

class CompanyProvider extends ChangeNotifier {
  List<Company> _companies = [];

  List<Company> get companies {
    return _companies;
  }

  Future<void> fetchCompanies() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.company));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<Company> loadedCompanies = [];

      body
          .map(
            (company) => loadedCompanies.add(
              Company(
                companyId: company["companyId"],
                district: District(
                  district: company["district"]["districtName"],
                  districtId: company["district"]["districtId"],
                ),
                companyHead: company["companyHead"],
                companyName: company["companyName"],
              ),
            ),
          )
          .toList();

      _companies = loadedCompanies;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }

  Future<Company> getCompany(int id) async {
    Company company = new Company();

    try {
      var response = await http.get(Uri.parse("${BaseURL.company}/$id"));
      var body = jsonDecode(response.body);

      if (body["companyId"] == 0) {
        return company;
      }

      company = Company(
        companyId: body["companyId"],
        district: District(
          district: body["district"]["districtName"],
          districtId: body["district"]["districtId"],
        ),
        companyHead: body["companyHead"],
        companyName: body["companyName"],
      );
    } catch (err) {
      throw (err);
    }

    return company;
  }

  Future<void> addCompany(Company company) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.company),
        body: json.encode(
          {
            "district": {
              "districtId": company.district!.districtId,
            },
            "CompanyName": company.companyName,
            "CompanyHead": company.companyHead,
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

  Future<void> updateCompany(int id, Company company) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.company}/$id"),
        body: json.encode(
          {
            "district": {
              "districtId": company.district!.districtId,
            },
            "CompanyName": company.companyName,
            "CompanyHead": company.companyHead,
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

  Future<void> deleteCompany(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.company}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

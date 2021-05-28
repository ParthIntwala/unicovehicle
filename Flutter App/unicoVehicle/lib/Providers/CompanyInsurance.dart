import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/InsuranceType.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/InsuranceCompany.dart';

class CompanyInsuranceProvider extends ChangeNotifier {
  List<InsuranceType> _insuranceType = [];

  List<InsuranceType> get insuranceType {
    return _insuranceType;
  }

  Future<void> fetchInsuranceType(int id) async {
    try {
      var response =
          await http.get(Uri.parse("${BaseURL.companyInsurance}/$id"));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<InsuranceType> loadedInsuranceType = [];

      body
          .map(
            (insuranceType) => loadedInsuranceType.add(
              InsuranceType(
                insuranceTypeId: insuranceType["insuranceTypeId"],
                insuranceType: insuranceType["insuranceTypeName"],
                insuranceCompany: InsuranceCompany(
                  insuranceCompanyId: insuranceType["insuranceCompany"]
                      ["insuranceCompanyId"],
                  insuranceCompany: insuranceType["insuranceCompany"]
                      ["insuranceCompanyName"],
                ),
              ),
            ),
          )
          .toList();

      _insuranceType = loadedInsuranceType;

      notifyListeners();
    } catch (err) {
      throw err;
    }
  }
}

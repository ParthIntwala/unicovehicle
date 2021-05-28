import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/InsuranceType.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/InsuranceCompany.dart';

class InsuranceTypeProvider extends ChangeNotifier {
  List<InsuranceType> _insuranceType = [];

  List<InsuranceType> get insuranceType {
    return _insuranceType;
  }

  Future<void> fetchInsuranceType() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.insuranceType));

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

  Future<InsuranceType> getInsuranceType(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.insuranceType}/$id"));
      InsuranceType insuranceType = new InsuranceType();
      var body = jsonDecode(response.body);

      if (body["insuranceTypeId"] == 0) {
        return insuranceType;
      }

      insuranceType = InsuranceType(
        insuranceTypeId: body["insuranceTypeId"],
        insuranceType: body["insuranceTypeName"],
        insuranceCompany: InsuranceCompany(
          insuranceCompanyId: body["insuranceCompany"]["insuranceCompanyId"],
          insuranceCompany: body["insuranceCompany"]["insuranceCompanyName"],
        ),
      );

      return insuranceType;
    } catch (err) {
      throw err;
    }
  }

  Future<void> addInsuranceType(InsuranceType accessoriesType) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.insuranceType),
        body: json.encode({
          "InsuranceTypeName": accessoriesType.insuranceType,
          "InsuranceCompany": {
            "InsuranceCompanyId":
                accessoriesType.insuranceCompany?.insuranceCompanyId,
          }
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

  Future<void> editInsuranceType(InsuranceType accessoriesType, int id) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.insuranceType}/$id"),
        body: json.encode({
          "InsuranceTypeName": accessoriesType.insuranceType,
          "InsuranceCompany": {
            "InsuranceCompanyId":
                accessoriesType.insuranceCompany?.insuranceCompanyId,
          }
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

  Future<void> deleteInsuranceType(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.insuranceType}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

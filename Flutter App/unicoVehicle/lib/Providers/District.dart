import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/District.dart';
import '../Utilities/BaseURL.dart';
import '../Models/State.dart' as local;
import '../Models/Country.dart';
import '../Models/Detailed/District.dart' as districts;

class DistrictProvider extends ChangeNotifier {
  Future<void> addDistrict(District district) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.district),
        body: json.encode({
          "DistrictName": district.district,
          "State": {
            "StateId": district.state?.stateId,
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

  Future<void> deleteDistrict(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.district}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }

  Future<districts.District> getDistrict(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.district}/$id"));
      districts.District district = new districts.District();
      var body = jsonDecode(response.body);

      if (body["districtId"] == 0) {
        return district;
      }

      district = districts.District(
        districtId: body["districtId"],
        district: body["districtName"],
        state: local.State(
            stateId: body["state"]["stateId"],
            state: body["state"]["stateName"],
            country: Country(
              country: body["state"]["countryName"]["countryName"],
              countryId: body["state"]["countryName"]["countryId"],
            )),
      );

      return district;
    } catch (err) {
      throw err;
    }
  }
}

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/District.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Miscellaneous/State.dart' as MiscellaneousState;

class DistrictStateProvider extends ChangeNotifier {
  List<District> _districts = [];

  List<District> get districts {
    return _districts;
  }

  Future<void> fetchDistrict(int id) async {
    try {
      var response = await http.get(Uri.parse("${BaseURL.districtState}/$id"));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<District> loadedDistricts = [];

      print(body);

      body
          .map(
            (district) => loadedDistricts.add(
              District(
                districtId: district["districtId"],
                district: district["districtName"],
                state: MiscellaneousState.State(
                  state: district["state"]["stateName"],
                  stateId: district["state"]["stateId"],
                ),
              ),
            ),
          )
          .toList();

      _districts = loadedDistricts;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }
}

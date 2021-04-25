import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/FuelType.dart';
import '../Utilities/BaseURL.dart';

class FuelTypeProvider extends ChangeNotifier {
  List<FuelType> _fuelType = [];

  List<FuelType> get fuelType {
    return _fuelType;
  }

  Future<void> fetchFuelType() async {
    try {
      var response = await http.get(
        Uri.parse(BaseURL.fuelTypeUrl),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<FuelType> loadedfuelType = [];

      body
          .map(
            (fuelType) => loadedfuelType.add(
              FuelType(
                fuelType: fuelType["fuelTypeName"],
                fuelTypeId: fuelType["fuelTypeId"],
              ),
            ),
          )
          .toList();

      _fuelType = loadedfuelType;

      notifyListeners();
    } catch (err) {
      throw err;
    }
  }

  Future<void> addFuelType(FuelType fuelType) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.fuelTypeUrl),
        body: json.encode({
          "FuelTypeName": fuelType.fuelType,
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

  Future<void> deleteFuelType(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.fuelTypeUrl}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

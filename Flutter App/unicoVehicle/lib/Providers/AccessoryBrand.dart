import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/AccessoriesBrand.dart';
import '../Utilities/BaseURL.dart';

class AccessoryBrandProvider extends ChangeNotifier {
  List<AccessoriesBrand> _accessoriesBrand = [];

  List<AccessoriesBrand> get accessoriesBrand {
    return _accessoriesBrand;
  }

  Future<void> fetchAccessoriesBrand() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.accessoryBrand));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<AccessoriesBrand> loadedAccessoriesBrand = [];

      body
          .map(
            (fuelType) => loadedAccessoriesBrand.add(
              AccessoriesBrand(
                accessoriesBrand: fuelType["accessoryBrandName"],
                accessoriesBrandId: fuelType["accessoryBrandId"],
              ),
            ),
          )
          .toList();

      _accessoriesBrand = loadedAccessoriesBrand;

      notifyListeners();
    } catch (err) {
      throw err;
    }
  }

  Future<void> addAccessoriesBrand(AccessoriesBrand accessoriesBrand) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.accessoryBrand),
        body: json.encode({
          "AccessoryBrandName": accessoriesBrand.accessoriesBrand,
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

  Future<void> deleteAccessoriesBrand(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.accessoryBrand}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

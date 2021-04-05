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
    var response = await http.get(Uri.parse(BaseURL.fuelTypeUrl));
    print(jsonDecode(response.body));
  }
}

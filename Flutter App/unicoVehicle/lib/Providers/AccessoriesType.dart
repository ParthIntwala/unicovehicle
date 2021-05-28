import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/AccessoriesType.dart';
import '../Utilities/BaseURL.dart';

class AccessoriesTypeProvider extends ChangeNotifier {
  List<AccessoriesType> _accessoriesType = [];

  List<AccessoriesType> get accessoriesType {
    return _accessoriesType;
  }

  Future<void> fetchAccessoriesType() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.accessoriesType));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<AccessoriesType> loadedAccessoriesType = [];

      body
          .map(
            (accessoryType) => loadedAccessoriesType.add(
              AccessoriesType(
                accessoriesType: accessoryType["accessories"],
                accessoriesTypeId: accessoryType["accessoriesTypeId"],
              ),
            ),
          )
          .toList();

      _accessoriesType = loadedAccessoriesType;

      notifyListeners();
    } catch (err) {
      throw err;
    }
  }

  Future<void> addAccessoriesType(AccessoriesType accessoriesType) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.accessoriesType),
        body: json.encode({
          "Accessories": accessoriesType.accessoriesType,
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

  Future<void> deleteAccessoriesType(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.accessoriesType}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/BoughtAccessories.dart';
import '../Utilities/BaseURL.dart';
import '../Models/Accessories.dart';
import '../Models/AccessoriesBrand.dart';
import '../Models/AccessoriesType.dart';
import '../Models/VehicleName.dart';
import '../Models/Miscellaneous/Company.dart';

class BoughtAccessoriesProvider extends ChangeNotifier {
  late AccessoriesBought _accessoriesBought;

  AccessoriesBought get accessoriesBought {
    return _accessoriesBought;
  }

  Future<void> fetchAccessoriesBought(int id) async {
    try {
      var response =
          await http.get(Uri.parse(BaseURL.boughtAccessories + "/$id"));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<BoughtAccessories> bought = [];

      body.map((product) {
        bought.add(
          BoughtAccessories(
            accessoriesId: product["boughtAccessoriesId"],
            accessories: new Accessories(
              accessoriesName: product["accessories"]["accessoriesName"],
              price: product["accessories"]["price"],
              accessoriesBrand: new AccessoriesBrand(
                accessoriesBrand: product["accessories"]["accessoryBrand"]
                    ["accessoryBrandName"],
                accessoriesBrandId: product["accessories"]["accessoryBrand"]
                    ["accessoryBrandId"],
              ),
              accessoriesId: product["accessories"]["accessoriesId"],
              accessoriesType: new AccessoriesType(
                accessoriesType: product["accessories"]["accessoriesType"]
                    ["accessories"],
                accessoriesTypeId: product["accessories"]["accessoriesType"]
                    ["accessoriesTypeId"],
              ),
              vehicleName: new VehicleName(
                company: new Company(
                  company: product["accessories"]["vehicleName"]["company"]
                      ["companyName"],
                  companyId: product["accessories"]["vehicleName"]["company"]
                      ["companyId"],
                ),
                vehicleName: product["accessories"]["vehicleName"]["name"],
                vehicleNameId: product["accessories"]["vehicleName"]
                    ["vehicleNameId"],
              ),
            ),
          ),
        );
      }).toList();

      AccessoriesBought loadedAccessories = new AccessoriesBought(
        orderId: id,
        accessories: bought,
      );

      _accessoriesBought = loadedAccessories;

      notifyListeners();
    } catch (err) {
      print(err);
    }
  }

  Future<void> addBoughtAccessories(
      int id, List<BoughtAccessories> accessoriesBought) async {
    List<Map<String, dynamic>> body = [];

    accessoriesBought.forEach((element) {
      body.add({
        "Accessories": {"AccessoriesId": element.accessories.accessoriesId}
      });
    });

    String bodyString = body.toString();

    try {
      print("ABC");
      var response = await http.post(
        Uri.parse(BaseURL.boughtAccessories + "/$id"),
        body: json.encode(body),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
      print("XYZ");
    } catch (err) {
      throw (err);
    }
  }

  Future<void> updateAccessoriesBrand(
      int id, List<BoughtAccessories> accessoriesBought) async {
    List<Map<String, dynamic>> body = [];

    accessoriesBought.forEach((element) {
      body.add({
        "Accessories": {"AccessoriesId": element.accessories.accessoriesId}
      });
    });

    try {
      print("ABC");
      var response = await http.put(
        Uri.parse(BaseURL.boughtAccessories + "/$id"),
        body: json.encode(body),
        headers: {
          "Accept": "application/json",
          "Content-Type": "application/json"
        },
      );
      print("XYZ");
    } catch (err) {
      throw (err);
    }
  }
}

class AccessoriesBought {
  final int? orderId;
  final List<BoughtAccessories> accessories;

  AccessoriesBought({
    required this.accessories,
    this.orderId,
  });
}

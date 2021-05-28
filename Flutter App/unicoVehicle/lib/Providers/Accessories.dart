import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;
import 'dart:convert';

import '../Models/Accessories.dart';
import '../Utilities/BaseURL.dart';
import '../Models/AccessoriesBrand.dart';
import '../Models/AccessoriesType.dart';
import '../Models/VehicleName.dart';
import '../Models/Miscellaneous/Company.dart';

class AccessoriesProvider extends ChangeNotifier {
  List<Accessories> _accessories = [];

  List<Accessories> get accessories {
    return _accessories;
  }

  Future<void> fetchAccessories() async {
    try {
      var response = await http.get(Uri.parse(BaseURL.accessories));

      if (response.body.isEmpty) {
        return;
      }

      var body = jsonDecode(response.body) as List<dynamic>;
      List<Accessories> loadedAccessories = [];

      body
          .map(
            (accessory) => loadedAccessories.add(
              Accessories(
                accessoriesBrand: AccessoriesBrand(
                  accessoriesBrand: accessory["accessoryBrand"]
                      ["accessoriesBrandName"],
                  accessoriesBrandId: accessory["accessoryBrand"]
                      ["accessoriesBrandId"],
                ),
                accessoriesId: accessory["accessoriesId"],
                accessoriesName: accessory["accessoriesName"],
                accessoriesType: AccessoriesType(
                  accessoriesType: accessory["accessoriesType"]["accessories"],
                  accessoriesTypeId: accessory["accessoriesType"]
                      ["accessoriesTypeId"],
                ),
                price: accessory["price"],
                vehicleName: VehicleName(
                  company: Company(
                    company: accessory["vehicleName"]["company"]["companyName"],
                    companyId: accessory["vehicleName"]["company"]["companyId"],
                  ),
                  vehicleName: accessory["vehicleName"]["name"],
                  vehicleNameId: accessory["vehicleName"]["vehicleNameId"],
                ),
              ),
            ),
          )
          .toList();

      _accessories = loadedAccessories;

      notifyListeners();
    } catch (err) {
      throw (err);
    }
  }

  Future<void> addAccessories(Accessories accessories) async {
    try {
      var response = await http.post(
        Uri.parse(BaseURL.accessories),
        body: json.encode({
          'AccessoriesType': {
            'AccessoriesTypeId': accessories.accessoriesType!.accessoriesTypeId
          },
          'AccessoriesName': accessories.accessoriesName,
          'AccessoryBrand': {
            'AccessoryBrandId':
                accessories.accessoriesBrand!.accessoriesBrandId,
          },
          'Price': accessories.price,
          'VehicleName': {
            'VehicleNameId': accessories.vehicleName!.vehicleNameId,
          },
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

  Future<void> updateAccessories(int id, Accessories accessories) async {
    try {
      var response = await http.put(
        Uri.parse("${BaseURL.accessories}/$id"),
        body: json.encode({
          "AccessoriesName": accessories.accessoriesName,
          "Price": accessories.price
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

  Future<void> deleteAccessories(int id) async {
    try {
      var response = await http.delete(
        Uri.parse("${BaseURL.accessories}/$id"),
      );
    } catch (err) {
      throw (err);
    }
  }
}

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
      var response = await http
          .get(Uri.parse(BaseURL.boughtAccessories + "/$id"))
          .then((value) => print(value));

      // if (response.body.isEmpty) {
      //   return;
      // }

      // var body = jsonDecode(response.body) as List<dynamic>;
      List<BoughtAccessories> bought = [];

      //print(body[0]);

      // body.map((product) {
      //   product.forEach((key, value) {
      //     bought.add(
      //       BoughtAccessories(
      //         boughtAccessoriesId: value["boughtAccessoriesId"],
      //         accessories: new Accessories(
      //           accessoriesName: value["accessories"]["accessoriesName"],
      //           price: value["price"],
      //           accessoriesBrand: new AccessoriesBrand(
      //             accessoriesBrand: value["accessories"]["accessoryBrand"]
      //                 ["accessoryBrandName"],
      //             accessoriesBrandId: value["accessories"]["accessoryBrand"]
      //                 ["accessoryBrandId"],
      //           ),
      //           accessoriesId: value["accessories"]["accessoriesId"],
      //           accessoriesType: new AccessoriesType(
      //             accessoriesType: value["accessories"]["accessoriesType"]
      //                 ["accessories"],
      //             accessoriesTypeId: value["accessories"]["accessoriesType"]
      //                 ["accessoriesTypeId"],
      //           ),
      //           vehicleName: new VehicleName(
      //             company: new Company(
      //               company: value["accessories"]["vehicleName"]["company"]
      //                   ["companyName"],
      //               companyId: value["accessories"]["vehicleName"]["company"]
      //                   ["companyId"],
      //             ),
      //             vehicleName: value["accessories"]["vehicleName"]["name"],
      //             vehicleNameId: value["accessories"]["vehicleName"]
      //                 ["vehicleNameId"],
      //           ),
      //         ),
      //       ),
      //     );
      //   });
      // }).toList();

      AccessoriesBought loadedAccessories = new AccessoriesBought(
        orderId: id,
        accessories: bought,
      );

      _accessoriesBought = loadedAccessories;

      print(_accessoriesBought.accessories);

      notifyListeners();
    } catch (err) {
      print(err);
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

class AccessoriesBought {
  final int? orderId;
  final List<BoughtAccessories> accessories;

  AccessoriesBought({
    required this.accessories,
    this.orderId,
  });
}
